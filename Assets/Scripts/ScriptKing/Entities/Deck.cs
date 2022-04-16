using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleOfKingdoms.Game.Cards;

namespace BattleOfKingdoms.Game.Entities
{
    public class Deck : MonoBehaviour
    {
        private Stack<ICardEvent> m_eventCards = new Stack<ICardEvent>();
        private Stack<ICardResource> m_resourceCards = new Stack<ICardResource>();

        public int SizeDeck = 128;
        [SerializeField] private float f_eventToResource = 0.25f;

        private CardFactory m_cardFactory = new CardFactory();

        public Deck()
        {
            int countEventCards = (int)(SizeDeck * f_eventToResource);
            int countResourceCards = SizeDeck - countEventCards;
            
            for(int i = 0; i < countEventCards; i++)
            {
                m_eventCards.Push(m_cardFactory.CreateEventCard());
            }

            for(int i = 0; i < countResourceCards; i++)
            {
                m_resourceCards.Push(m_cardFactory.CreateResourceCard());
            }
        }

        public void GetCard()
        {
        }
    }
}
