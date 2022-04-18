using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleOfKingdoms.Game.Cards
{
    public interface ICard
    {
        abstract ICardEvent CreateEventCard(EventCardType eventType);
        abstract ICardResource CreateResourceCard(ResourceCardType resourceType);
    }
}
