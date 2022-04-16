using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleOfKingdoms.Game.Cards
{
    public class CardFactory : ICard
    {
        public ICardEvent CreateEventCard()
        {
            return new WarEventCard();
        }

        public ICardResource CreateResourceCard()
        {
            return new ResourceWood();
        }
    }
}
