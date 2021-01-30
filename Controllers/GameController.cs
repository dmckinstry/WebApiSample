using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GameServer.Models;

namespace GameServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly ILogger<GameController> _logger;

        public GameController(ILogger<GameController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Game> GetAllGames()
        {
            return Game.ActiveGames;
        }

        // [HttpGet]
        [HttpPost]
        public IEnumerable<Game> CreateNewGame(String player, int duration)
        {
            // For some reason ASP.NET isn't correctly capturing params in the FORM body, so a temp workaround...
            if ((player == null) && (this.Request.HasFormContentType) && (this.Request.Form["player"].Count > 0))
            {
                player = this.Request.Form["player"][0];
                duration = int.Parse(this.Request.Form["duration"][0]);
            }

            if (player != null)
                new Game(player, duration );
            return Game.ActiveGames;
        }

    }
}
