using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleOfKingdoms.Game.Cards
{
    public enum EventCardType
    {
        War,
        Peace
    }

    public enum ResourceCardType
    {
        Wood
    }

    public class CardFactory : ICard
    {
        public ICardEvent CreateEventCard(EventCardType eventType)
        {
            switch (eventType)
            {
                case EventCardType.War:
                    return new WarEventCard();
                case EventCardType.Peace:
                    return new PeaceEvent();
                default:
                    return null;
            }
        }

        public ICardResource CreateResourceCard(ResourceCardType resourceType)
        {
            switch (resourceType)
            {
                case ResourceCardType.Wood:
                    return new ResourceWood();
                default:
                    return null;
            }
        }
    }
}
