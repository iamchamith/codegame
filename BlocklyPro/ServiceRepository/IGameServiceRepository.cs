using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlocklyPro.Models;
using BlocklyPro.Utility;

namespace BlocklyPro.ServiceRepository
{
    public interface IGameServiceRepository
    {
        Task<GameModel> ReadGame(Request<int> request);
        Task<GameModel> CreateGame(Request<GameModel> request);
        Task UpdateGame(Request<GameModel> request);
        Task DeleteGame(Request<int> request);
        Task<List<KeyValuePair<int, string>>> GetGames(Request<bool> request);
        Task<List<KeyValuePair<int, string>>> GetPublishGames(Request<bool> request);
        Task<List<KeyValuePair<int, string>>> GetMyGames(Request<bool> request);
        Task<List<GameMapModel>> GetGameMap(Request<int> request);
        Task<List<GameMapModel>> SaveGameMap(Request<int,List<GameMapModel>> request);

        //play
        Task<List<KeyValuePair<int, string>>> GetGamePlays(Request<int> request);
        Task<PlayGameModel> GetGamePlaysCode(Request<int> request);
        Task CreateGamePlays(Request<PlayGameModel> request);
        Task<PlayGameModel> GetGameSolution(Request<int> request);
        Task<List<KeyValuePair<DateTime, int>>> GetMarksByGameId(Request<int> request);
    }
}
