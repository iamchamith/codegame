using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlocklyPro.Core.AppService.Dto.Play;
using BlocklyPro.Core.Utility;

namespace BlocklyPro.Core.AppService.Interfaces
{
    public interface IGameRunnerAppService
    {
        Task Create(Request<PlayGameDto> request);
        Task<List<KeyValuePair<int, string>>> ReadPlayGameList(Request<int, int> request);
        Task<PlayGameDto> ReadPlayGame(Request<int> request);
    }
}
