using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlocklyPro.Api.Model.Game;
using BlocklyPro.Api.Model.Play;
using BlocklyPro.Core.AppService.Dto.GameDto;
using BlocklyPro.Core.AppService.Dto.Play;
using BlocklyPro.Core.AppService.Interfaces;
using BlocklyPro.Core.Utility;
using Microsoft.AspNetCore.Mvc;

namespace BlocklyPro.Api.Controllers.V1
{
    [Route(Version + "games")]
    public class GameController : V1BaseController
    {
        private readonly IGameAppService _gameAppService;
        private readonly IGameRunnerAppService _gameRunnerAppService;
        public GameController(IGameAppService gameAppService,
            IGameRunnerAppService gameRunnerAppService,
            ICoreInjector coreInjector) : base(coreInjector)
        {
            _gameAppService = gameAppService;
            _gameRunnerAppService = gameRunnerAppService;
        }
        #region game
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetGame(int id)
        {
            try
            {
                _httpContext = HttpContext;
                var result = await _gameAppService.ReadGame(Request(id));
                return Ok(_mapper.Map<GameModel>(result));
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateGame([FromBody]GameModel item)
        {
            try
            {
                _httpContext = HttpContext;
                var result = await _gameAppService.CreateGame(Request(_mapper.Map<GameDto>(item)));
                return Ok(_mapper.Map<GameModel>(result));
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateGame([FromBody]GameModel item)
        {
            try
            {
                _httpContext = HttpContext;
                await _gameAppService.UpdateGame(Request(_mapper.Map<GameDto>(item)));
                return Ok();
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            try
            {
                _httpContext = HttpContext;
                await _gameAppService.DeleteGame(Request(id));
                return Ok();
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetGames()
        {
            try
            {
                _httpContext = HttpContext;
                var result = await _gameAppService.GetGames(Request((bool?)null));
                return Ok(result);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }
        [HttpGet("publish")]
        public async Task<IActionResult> GetPublishGames()
        {
            try
            {
                _httpContext = HttpContext;
                var result = await _gameAppService.GetPublishGames(Request(false));
                return Ok(result);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }
        [HttpGet, Route("my")]
        public async Task<IActionResult> GetMyGames()
        {
            try
            {
                _httpContext = HttpContext;
                var result = await _gameAppService.GetMyGames(Request(false));
                return Ok(result);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }
        #endregion


        #region game map

        [HttpGet("{id:int}/maps")]
        public async Task<IActionResult> GetGameMap(int id)
        {
            try
            {
                _httpContext = HttpContext;
                var result = await _gameAppService.GetGameMap(Request(id));
                return Ok(result);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }
        [HttpPut("{id:int}/maps")]
        public async Task<IActionResult> SaveGameMap(int id, [FromBody]List<GameMapModel> items)
        {
            try
            {
                _httpContext = HttpContext;
                var dto = _mapper.MapList<GameMapModel, GameMapDto>(items);
                await _gameAppService.SaveGameMap(Request(id, dto));
                return Ok();
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }
        #endregion

        #region playgame
        [HttpGet("{gameid:int}/plays/{playerid:int}")]
        public async Task<IActionResult> GetGamePlays(int gameid, int playerid)
        {
            try
            {
                _httpContext = HttpContext;
                playerid = playerid == 0 ? UserId : playerid;
                var result = await _gameRunnerAppService.ReadPlayGameList(Request(playerid, gameid));
                return Ok(result);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        [HttpGet("codes/{gameplayid:int}")]
        public async Task<IActionResult> GetGamePlaysCode(int gameplayid)
        {
            try
            {
                _httpContext = HttpContext;
                var result = await _gameRunnerAppService.ReadPlayGame(Request(gameplayid));
                var fresult = _mapper.Map<PlayGameDto, PlayGameModel>(result);
                return Ok(fresult);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }
        [HttpPost("plays")]
        public async Task<IActionResult> CreateGamePlays([FromBody] PlayGameModel model)
        {
            try
            {
                _httpContext = HttpContext;
                var dto = _mapper.Map<PlayGameModel, PlayGameDto>(model);
                await _gameRunnerAppService.Create(Request(dto));
                return Ok();
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }
        #endregion
    }
}
