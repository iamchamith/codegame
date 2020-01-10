using System.Collections.Generic;
using System.Threading.Tasks;
using BlocklyPro.Models;
using BlocklyPro.Utility;

namespace BlocklyPro.ServiceRepository.Identity
{
    public class GameServiceRepository : BaseServiceRepository, IGameServiceRepository
    {
        private readonly IXHRServiceRepository _serviceRepository;
        private string readGameEndpoint = "/games/{0}";
        private string createGameEndpoint = "/games";
        private string updateGameEndPoint = "/games";
        private string deleteGameEndPoint = "/games/{0}";
        private string getGamesEndPoint = "/games";
        private string getPublishGamesEndpoint = "/games/publish";
        private string getMyGamesEndPoint = "/games/my";
        private string getGameMapEndPoint = "/games/{0}/maps";
        private string saveGameMapEndPoint = "/games/{0}/maps";

        private string getGamePlaysEndpoint = "/games/{0}/plays/{1}";
        private string getGamePlaysCodeEndpoint = "/games/codes/{0}";
        private string createGamePlaysEndpoint = "/games/plays";
        private string gameSolutionEndpoint = "/games/{0}/solutions";

        public GameServiceRepository(IXHRServiceRepository serviceRepository) : base("/api/v1")
        {
            createGameEndpoint = BaseApiEndpoint.AsUrlCombineWith(createGameEndpoint);
            deleteGameEndPoint = BaseApiEndpoint.AsUrlCombineWith(deleteGameEndPoint);
            getGamesEndPoint = BaseApiEndpoint.AsUrlCombineWith(getGamesEndPoint);
            getMyGamesEndPoint = BaseApiEndpoint.AsUrlCombineWith(getMyGamesEndPoint);
            getGameMapEndPoint = BaseApiEndpoint.AsUrlCombineWith(getGameMapEndPoint);
            saveGameMapEndPoint = BaseApiEndpoint.AsUrlCombineWith(saveGameMapEndPoint);
            updateGameEndPoint = BaseApiEndpoint.AsUrlCombineWith(updateGameEndPoint);
            readGameEndpoint = BaseApiEndpoint.AsUrlCombineWith(readGameEndpoint);
            getPublishGamesEndpoint = BaseApiEndpoint.AsUrlCombineWith(getPublishGamesEndpoint);

            getGamePlaysEndpoint = BaseApiEndpoint.AsUrlCombineWith(getGamePlaysEndpoint);
            getGamePlaysCodeEndpoint = BaseApiEndpoint.AsUrlCombineWith(getGamePlaysCodeEndpoint);
            createGamePlaysEndpoint = BaseApiEndpoint.AsUrlCombineWith(createGamePlaysEndpoint);
            gameSolutionEndpoint = BaseApiEndpoint.AsUrlCombineWith(gameSolutionEndpoint);
            _serviceRepository = serviceRepository;

        }
        public async Task<GameModel> ReadGame(Request<int> request)
        {

            return await _serviceRepository.Get<GameModel>(request.ToXhrRequest(string.Format(readGameEndpoint, request.Item)));
        }
        public async Task<GameModel> CreateGame(Request<GameModel> request)
        {
            return await _serviceRepository.Post<GameModel>(request.ToXhrRequest(createGameEndpoint));
        }
        public async Task UpdateGame(Request<GameModel> request)
        {
            await _serviceRepository.Put<GameModel>(request.ToXhrRequest(updateGameEndPoint));
        }
        public async Task DeleteGame(Request<int> request)
        {
            await _serviceRepository.Delete(request.ToXhrRequest(string.Format(deleteGameEndPoint, request.Item)));
        }

        public async Task<List<KeyValuePair<int, string>>> GetGames(Request<bool> request)
        {
            return await _serviceRepository.Get<List<KeyValuePair<int, string>>>(request.ToXhrRequest(getGamesEndPoint));
        }
        public async Task<List<KeyValuePair<int, string>>> GetPublishGames(Request<bool> request)
        {
            return await _serviceRepository.Get<List<KeyValuePair<int, string>>>(request.ToXhrRequest(getPublishGamesEndpoint));
        }
        public async Task<List<KeyValuePair<int, string>>> GetMyGames(Request<bool> request)
        {
            return await _serviceRepository.Get<List<KeyValuePair<int, string>>>(request.ToXhrRequest(getMyGamesEndPoint));
        }

        // game map
        public async Task<List<GameMapModel>> GetGameMap(Request<int> request)
        {
            return await _serviceRepository.Get<List<GameMapModel>>(
                request.ToXhrRequest(string.Format(getGameMapEndPoint, request.Item)));
        }
        public async Task<List<GameMapModel>> SaveGameMap(Request<int, List<GameMapModel>> request)
        {
            return await _serviceRepository.Put<List<GameMapModel>>(
                new XhrRequest(string.Format(saveGameMapEndPoint, request.Item1), request.Item2).SetToken(request.Token));
        }

        //game plays

        public async Task<List<KeyValuePair<int, string>>> GetGamePlays(Request<int> request)
        {
            return await _serviceRepository.Get<List<KeyValuePair<int, string>>>(
                request.ToXhrRequest(string.Format(getGamePlaysEndpoint, request.Item, "0")));
        }
        public async Task<PlayGameModel> GetGamePlaysCode(Request<int> request)
        {
            return await _serviceRepository.Get<PlayGameModel>(
                request.ToXhrRequest(string.Format(getGamePlaysCodeEndpoint, request.Item)));
        }
        public async Task CreateGamePlays(Request<PlayGameModel> request)
        {
            await _serviceRepository.Post<PlayGameModel>(
              request.ToXhrRequest(createGamePlaysEndpoint));
        }

        public async Task<PlayGameModel> GetGameSolution(Request<int> request)
        {
            return await _serviceRepository.Get<PlayGameModel>(
                request.ToXhrRequest(string.Format(gameSolutionEndpoint, request.Item)));
        }
    }
}
