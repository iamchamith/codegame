using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlocklyPro.Core.AppService.Dto.Play;
using BlocklyPro.Core.AppService.Interfaces;
using BlocklyPro.Core.Domain.Play;
using BlocklyPro.Core.Infrastructure;
using BlocklyPro.Core.Utility;
using Microsoft.EntityFrameworkCore;

namespace BlocklyPro.Core.AppService
{
    public class GameRunnerAppService : BaseAppService, IGameRunnerAppService
    {
        public IUnitOfWork _unitOfWork { get; }

        public GameRunnerAppService(IUnitOfWork unitOfWork, ICoreInjector coreInjector) : base(coreInjector)
        {
            _unitOfWork = unitOfWork;
        }

        #region submit play game result
        public async Task Create(Request<PlayGameDto> request)
        {
            try
            {
                var game = await _unitOfWork.GameRepository.TableAsNoTracking
                    .SingleOrDefaultAsync(p => p.Id == request.Item.GameId);

                if (game.IsNull())
                    throw new RecordNotFoundException("There is no game to found");

                if (request.Item.GameCodes.IsNullOrEmpty())
                    throw new InvalidDataException("Game must have source code");

                if (game.IsPublish && game.UserId.Is(request.UserId))
                    throw new InvalidDataException("Game creator cannot submit the solution");

                if (!game.IsPublish && game.UserId.Is(request.UserId))
                {
                    var request2 = new Request<PlayGameDto, bool>(request.Item, true, request.UserId);
                    await DeleteDefaultSolution(request);
                    await SubmitASolutionSolution(request2);
                }
                else
                {
                    var request2 = new Request<PlayGameDto, bool>(request.Item, false, request.UserId);
                    await SubmitASolutionSolution(request2);
                }
                await _unitOfWork.SaveAsync();
            }
            catch (Exception e)
            {
                throw e.HandleException();
            }
        }
        async Task SubmitASolutionSolution(Request<PlayGameDto, bool> request)
        {
            var code = new List<GameCode>();
            request.Item1.GameCodes.ForEach(item =>
            {
                code.Add(new GameCode(item.Order, item.CodeType, item.Payload));
            });
            var gamePlay = new PlayGame(request.Item1.GameId,
                    request.UserId)
                .SaveCode(code)
                .SetScore(true);
            if (request.Item2)
                gamePlay.SetAsCorrectGame();
            await _unitOfWork.PlayGameRepository.CreateAndSave(gamePlay);
        }

        async Task DeleteDefaultSolution(Request<PlayGameDto> request)
        {
            var gamePlay =
                await _unitOfWork.PlayGameRepository.Table
                    .Include(p => p.GameCode)
                    .SingleOrDefaultAsync(p =>
                    p.GameId == request.Item.GameId && p.IsCorrectSolution);
            if (!gamePlay.IsNull())
                _unitOfWork.PlayGameRepository.Delete(gamePlay);
        }

        #endregion

        #region reads
        public async Task<List<KeyValuePair<int, string>>> ReadPlayGameList(Request<int, int> request)
        {
            try
            {
                return await _unitOfWork.PlayGameRepository.TableAsNoTracking
                    .Where(p => p.GameId == request.Item2 && p.PlayerId == request.Item1)
                    .Select(p => new KeyValuePair<int, string>(p.Id, $"{p.CreatedOn.ToShortDateString()} {p.CreatedOn.ToShortTimeString()}"))
                    .ToListAsync();
            }
            catch (Exception e)
            {
                throw e.HandleException();
            }
        }

        public async Task<PlayGameDto> ReadPlayGame(Request<int> request)
        {
            try
            {
                var result = await _unitOfWork.PlayGameRepository.TableAsNoTracking
                    .Include(p => p.GameCode)
                    .Where(p => p.Id == request.Item)
                    .SingleOrDefaultAsync();
                if (result.IsNull())
                    throw new RecordNotFoundException();
                var finalResult = _mapper.Map<PlayGameDto>(result);
                result.GameCode.ForEach(item => { finalResult.SetGameCode(_mapper.Map<GameCodeDto>(item)); });
                return finalResult;
            }
            catch (Exception e)
            {
                throw e.HandleException();
            }
        }

        public async Task<PlayGameDto> ReadGameSolution(Request<int> request)
        {
            try
            {
                var result = await _unitOfWork.PlayGameRepository.TableAsNoTracking
                    .Include(p => p.GameCode)
                    .Where(p => p.GameId == request.Item && p.IsCorrectSolution)
                    .SingleOrDefaultAsync();
                if (result.IsNull())
                    throw new RecordNotFoundException();
                var finalResult = _mapper.Map<PlayGameDto>(result);
                result.GameCode.ForEach(item => { finalResult.SetGameCode(_mapper.Map<GameCodeDto>(item)); });
                return finalResult;
            }
            catch (Exception e)
            {
                throw e.HandleException();
            }
        }

        public async Task<List<KeyValuePair<DateTime, int>>> GetMarksByGameId(Request<int> request)
        {
            try
            {
                var result = await _unitOfWork.PlayGameRepository.TableAsNoTracking
                    .Where(p => !p.IsCorrectSolution
                                && p.PlayerId == request.UserId && p.GameId == request.Item)
                    .OrderBy(p=>p.CreatedOn)
                    .Select(p => new KeyValuePair<DateTime, int>(p.CreatedOn, p.Score))
                    .ToListAsync();
                return result;
            }
            catch (Exception e)
            {
                throw e.HandleException();
            }
        }

        #endregion
    }
}
