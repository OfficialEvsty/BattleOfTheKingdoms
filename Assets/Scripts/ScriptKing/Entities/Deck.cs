using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleOfKingdoms.Game.Cards;

namespace BattleOfKingdoms.Game.Entities
{
    public class Deck : MonoBehaviour
    {
        [SerializeField] private DeckInitializer m_deckInitializer;

        private Stack<ICardEvent> m_eventCards = new Stack<ICardEvent>();
        private Stack<ICardResource> m_resourceCards = new Stack<ICardResource>();

        public int SizeEventDeck 
        { 
            get 
            { 
                if(m_deckInitializer)
                    return m_deckInitializer.EventCardsInDeck.Count;
                return 0;
            } 
        }

        public int SizeResourceDeck
        {
            get
            {
                if (m_deckInitializer)
                {
                    return m_deckInitializer.ResourceCardsInDeck.Count;
                }
                return 0;
            }
        }

        private CardFactory m_cardFactory = new CardFactory();       

        private void InitDesk()
        {
            foreach (var eventType in m_deckInitializer.EventCardsInDeck)
            {
                for (int i = 0; i < eventType.Value; i++)
                    m_eventCards.Push(m_cardFactory.CreateEventCard(eventType.Key));
            }

            foreach (var resourceType in m_deckInitializer.ResourceCardsInDeck)
            {
                for (int i = 0; i < resourceType.Value; i++)
                    m_resourceCards.Push(m_cardFactory.CreateResourceCard(resourceType.Key));
            }
        }

        private void Awake()
        {
            InitDesk();
            GetInfoAboutDecks();
        }

        public void GetInfoAboutDecks()
        {
            Debug.Log($"Cards in EventDeck: {m_eventCards.Count}\nCards in ResourceDeck: {m_resourceCards.Count}");
            foreach(var card in m_eventCards)
            {
                Debug.Log($"Card: {card.EventCardType}");
            }
            foreach(var card in m_resourceCards)
            {
                Debug.Log($"Card: {card.ResourceCardType}");
            }
        }

        public void GiveEventCard(Player player)
        {
            player.PlayerDeck.AddEventCard(m_eventCards.Pop());
        }
    }
}
