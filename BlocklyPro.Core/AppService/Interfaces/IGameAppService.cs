using System.Collections.Generic;
using System.Threading.Tasks;
using BlocklyPro.Core.AppService.Dto.GameDto;
using BlocklyPro.Core.Utility;

namespace BlocklyPro.Core.AppService.Interfaces
{
    public interface IGameAppService
    {
        Task<GameDto> ReadGame(Request<int> request);
        Task<GameDto> CreateGame(Request<GameDto> request);
        Task UpdateGame(Request<GameDto> request);
        Task DeleteGame(Request<int> request);
        Task<List<GameMapDto>> GetGameMap(Request<int> request);
        Task<List<KeyValuePair<int, string>>> GetGames(Request<bool?> request);
        Task<List<KeyValuePair<int, string>>> GetMyGames(Request<bool> request);
        Task SaveGameMap(Request<int, List<GameMapDto>> request);
        Task<List<KeyValuePair<int, string>>> GetPublishGames(Request<bool> request);
    }
}
