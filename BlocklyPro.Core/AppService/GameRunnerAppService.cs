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
        public async Task Create(Request<PlayGameDto> request)
        {
            try
            {
                if (request.Item.GameCodes.IsNullOrEmpty())
                    throw new InvalidDataException("Game must have source code");

                var code = new List<GameCode>();
                request.Item.GameCodes.ForEach(item =>
                    {
                        code.Add(new GameCode(item.Order, item.CodeType, item.Payload));
                    });
                var gamePlay = new PlayGame(request.Item.GameId,
                        request.UserId)
                    .SaveCode(code);
                await _unitOfWork.PlayGameRepository.CreateAndSave(gamePlay);
            }
            catch (Exception e)
            {
                throw e.HandleException();
            }
        }

        public async Task<List<KeyValuePair<int,string>>> ReadPlayGameList(Request<int,int> request)
        {
            try
            {
                return await _unitOfWork.PlayGameRepository.TableAsNoTracking
                    .Where(p => p.GameId == request.Item2 && p.PlayerId == request.Item1)
                    .Select(p => new KeyValuePair<int, string>(p.Id,$"{p.CreatedOn.ToShortDateString()} {p.CreatedOn.ToShortTimeString()}"))
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
                    .Where(p => p.GameId == request.Item)
                    .SingleAsync();
                if (result.IsNull())
                    throw new RecordNotFoundException();
                var finalResult =  _mapper.Map<PlayGameDto>(result);
                result.GameCode.ForEach(item => { finalResult.SetGameCode(_mapper.Map<GameCodeDto>(item)); });
                return finalResult;
            }
            catch (Exception e)
            {
                throw e.HandleException();
            }
        }
    }
}
