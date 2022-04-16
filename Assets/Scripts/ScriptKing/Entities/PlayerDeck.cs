using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleOfKingdoms.Game.Cards;

namespace BattleOfKingdoms.Game.Entities
{
    public class PlayerDeck : MonoBehaviour
    {
        private List<ICardEvent> m_eventCards = new List<ICardEvent>();
        private List<ICardResource> m_resourceCards = new List<ICardResource>();

        //private CardFactory m_cardFactory = new CardFactory();

        public void AddEventCard(ICardEvent cardEvent)
        {

        }

        public void AddResourceCard(ICardResource cardResource)
        {

        }

        public ICardEvent GetEventCard()
        {
            return null;
        }

        public ICardResource GetResourceCard()
        {
            return null;
        }
    }
}
