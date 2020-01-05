using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using AutoMapper;
using BlocklyPro.Api.Configurations;
using BlocklyPro.Core.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace BlocklyPro.Api.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly IMapper _mapper;
        protected HttpContext _httpContext;
        protected int _userId = 1;
        public BaseController(ICoreInjector coreInjector)
        {
            _mapper = coreInjector.Mapper;
        }

        protected int UserId
        {
            get
            {
                if ((HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token)))
                    _userId = Jwt.GetClaims(token.ToString());
                return _userId;
            }
        }

        public Request<T> Request<T>(T item)
        {
            return new Request<T>(item, UserId);
        }
        public Request<T1, T2> Request<T1, T2>(T1 item1, T2 item2)
        {
            return new Request<T1, T2>(item1, item2, _userId);
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        protected IActionResult HandleException(Exception ex)
        {
            if (ex is InvalidDataException)
            {
                return BadRequest(ex.Message);
            }
            else if (ex is RecordNotFoundException)
            {
                return BadRequest(ex.Message);
            }
            else if (ex is UnauthorizedException)
            {
                return BadRequest(ex.Message);
            }
            return StatusCode(500, ex.Message);
        }
    }
}
