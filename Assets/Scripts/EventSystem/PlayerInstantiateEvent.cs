using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleOfKingdoms.Game.Entities;

namespace BattleOfKingdoms.EventSystems
{
    public struct PlayerInstantiateEvent
    {
        public Player player;
        public string UserID;
    }
}
