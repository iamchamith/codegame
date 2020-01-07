using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlocklyPro.Core.AppService.Dto.GameDto;
using BlocklyPro.Core.AppService.Interfaces;
using BlocklyPro.Core.Domain;
using BlocklyPro.Core.Infrastructure;
using BlocklyPro.Core.Utility;
using Microsoft.EntityFrameworkCore;

namespace BlocklyPro.Core.AppService
{
    public class GameAppService : BaseAppService, IGameAppService
    {
        public IUnitOfWork _unitOfWork { get; }

        public GameAppService(IUnitOfWork unitOfWork, ICoreInjector coreInjector) : base(coreInjector)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GameDto> CreateGame(Request<GameDto> request)
        {
            try
            {
                var user = await _unitOfWork.UserRepository.TableAsNoTracking.FirstOrDefaultAsync(p =>
                    p.Id == request.UserId);
                var game = new Game(user)
                    .Create(request.Item.Name, request.Item.Time, request.Item.Instructions);
                var result = await _unitOfWork.GameRepository.Create(game);
                await _unitOfWork.SaveAsync();
                return _mapper.Map<GameDto>(result);
            }
            catch (Exception e)
            {
                throw e.HandleException();
            }
        }

        public async Task DeleteGame(Request<int> request)
        {
            try
            {
                var game = await _unitOfWork.GameRepository.Table
                    .Include(p => p.GameMap)
                    .FirstOrDefaultAsync(p => p.Id == request.Item);
                game.DeleteGame(request.UserId);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception e)
            {
                throw e.HandleException();
            }
        }

        public async Task UpdateGame(Request<GameDto> request)
        {
            try
            {
                var game = await _unitOfWork.GameRepository.Table
                    .Include(p => p.PlayGame)
                    .SingleAsync(p => p.Id == request.Item.Id);
                if (game.IsNull())
                    throw new RecordNotFoundException("Game was not founded");

                if (request.Item.IsPublish && !game.PlayGame.Any(p => p.IsCorrectSolution))
                    throw new InvalidDataException("Before publish the game, you need provide correct solution");

                game.UpdateGame(request.UserId, request.Item.Name, request.Item.Time, request.Item.Instructions,
                    request.Item.IsPublish);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception e)
            {
                throw e.HandleException();
            }
        }

        public async Task<GameDto> ReadGame(Request<int> request)
        {
            try
            {
                var game = await _unitOfWork.GameRepository.TableAsNoTracking
                    .SingleAsync(p => p.Id == request.Item);
                if (game.IsNull())
                    throw new RecordNotFoundException("Game was not founded");

                return _mapper.Map<GameDto>(game);
            }
            catch (Exception e)
            {
                throw e.HandleException();
            }
        }

        public async Task<List<GameMapDto>> GetGameMap(Request<int> request)
        {
            try
            {
                return (await _unitOfWork.GameMapRepository.TableAsNoTracking.Where(p => p.GameId == request.Item)
                        .ToListAsync())
                    .Select(_mapper.Map<GameMapDto>).ToList();
            }
            catch (Exception e)
            {
                throw e.HandleException();
            }
        }
        public async Task<List<KeyValuePair<int, string>>> GetGames(Request<bool?> request)
        {
            try
            {
                var query = _unitOfWork.GameRepository.TableAsNoTracking;
                query = (request.Item.HasValue) ? query.Where(p => p.IsPublish == request.Item) : query;
                return (await query.ToListAsync())
                    .Select(p => new KeyValuePair<int, string>(p.Id, p.Name)).ToList();
            }
            catch (Exception e)
            {
                throw e.HandleException();
            }
        }
        public async Task<List<KeyValuePair<int, string>>> GetPublishGames(Request<bool> request)
        {
            try
            {
                var query = _unitOfWork.GameRepository.TableAsNoTracking
                    .Include(p => p.User)
                    .Where(p => p.IsPublish
                                && p.UserId != request.UserId);
                return (await query.ToListAsync())
                    .Select(p => new KeyValuePair<int, string>(p.Id, $"{p.Name} by {p.User.Name}")).ToList();
            }
            catch (Exception e)
            {
                throw e.HandleException();
            }
        }
        public async Task<List<KeyValuePair<int, string>>> GetMyGames(Request<bool> request)
        {
            try
            {
                var result = (await _unitOfWork.GameRepository.TableAsNoTracking.Where(p => p.UserId == request.UserId).ToListAsync())
                    .Select(p => new KeyValuePair<int, string>(p.Id, $"{p.Name}({(p.IsPublish ? "Published" : "Not published")})")).ToList();
                return result;
            }
            catch (Exception e)
            {
                throw e.HandleException();
            }
        }

        public async Task SaveGameMap(Request<int, List<GameMapDto>> request)
        {
            using (var transaction = await _unitOfWork.Context.Database.BeginTransactionAsync())
            {
                try
                {
                    var game = await _unitOfWork.GameRepository.Table
                        .Include(p => p.GameMap)
                        .FirstOrDefaultAsync(p => p.Id == request.Item1);
                    if (!game.GameMap.IsZeroOrNull())
                        _unitOfWork.GameMapRepository.Delete(game.GameMap);
                    await _unitOfWork.Context.SaveChangesAsync();
                    var updatedMap = new List<GameMap>();
                    foreach (var item in request.Item2)
                    {
                        updatedMap.Add(new GameMap().CreateGameMap(item.ControllerType,
                            item.PointX, item.PointY, item.Height, item.Width));
                    }

                    game.AddGameMap(updatedMap);
                    await _unitOfWork.SaveAsync();
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw e.HandleException();
                }
            }
        }
    }
}

