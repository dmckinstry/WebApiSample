using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GameServer.Models
{
    public class Game
    {
        #region Accessors and member variables
        private int _guessNumber;
        private static Random _generator = new Random(DateTime.Now.Millisecond);
        private static List<Game> _activeGames = new List<Game>();
        public static List<Game> ActiveGames
        {
            get { return _activeGames; }
        }

        public Guid GameId { get; }
        public DateTime Starting { get; }
        public DateTime Ending { get; }
        public List<string> Players { get; }
        public String Winner { get; }
        #endregion

        public Game(string gameOwner, int length = 24)
        {
            this.Starting = DateTime.Now;
            this.Ending = Starting.AddHours(length);
            this.GameId = Guid.NewGuid();
            this._guessNumber = _generator.Next(1,100);
            this.Players = new List<string>();
            this.Players.Add(gameOwner);
            Game._activeGames.Add(this);
        }


    }
}
