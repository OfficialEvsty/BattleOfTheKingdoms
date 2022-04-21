using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleOfKingdoms.Game.Cards
{
    public class CardFactory : ICard
    {

        public ICardEvent CreateEventCard(CardEventScriptableObject cardEventSO)
        {
            return new EventCard(cardEventSO);
        }

        public ICardResource CreateResourceCard(CardResourceScriptableObject cardResourceSO)
        {
            return new ResourceCard(cardResourceSO);           
        }
    }
}
