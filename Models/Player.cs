using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GameServer.Models
{
    public class Player
    {
        #region Accessors and member variables
        public String Name { get; set; }
        #endregion

        public Player(string name)
        {
            this.Name = name;
        }
    }
}
