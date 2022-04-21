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
                    return m_deckInitializer.CardsEventDeck.Count;
                return 0;
            } 
        }

        public int SizeResourceDeck
        {
            get
            {
                if (m_deckInitializer)
                {
                    return m_deckInitializer.CardsResourceDeck.Count;
                }
                return 0;
            }
        }

        private CardFactory m_cardFactory = new CardFactory();       

        private void InitDeñk()
        {
            foreach (var cardEvent in m_deckInitializer.CardsEventDeck)
            {
                 m_eventCards.Push(m_cardFactory.CreateEventCard(cardEvent));
            }

            foreach (var cardResource in m_deckInitializer.CardsResourceDeck)
            {                
                m_resourceCards.Push(m_cardFactory.CreateResourceCard(cardResource));
            }
        }

        private void ShuffleEventDeck()
        {
            m_eventCards = ShuffleDeck(m_eventCards);
        }

        private void ShuffleResourceDeck()
        {
            m_resourceCards = ShuffleDeck(m_resourceCards);
        }

        private Stack<T> ShuffleDeck<T>(Stack<T> deckToShuffle)
        {
            T[] objectArray = deckToShuffle.ToArray();
            Stack<T> shuffledStack = new Stack<T>();
            for (int i = objectArray.Length - 1; i > 0; i--)
            {
                int randomIndex = Random.Range(0, i);
                var temp = objectArray[i];
                objectArray[i] = objectArray[randomIndex];
                objectArray[randomIndex] = temp;
            }

            for (int i = objectArray.Length - 1; i >= 0; i--)
            {
                shuffledStack.Push(objectArray[i]);
            }

            return shuffledStack;
        }


        private void Awake()
        {
            InitDeñk();
            ShuffleEventDeck();
            ShuffleResourceDeck();
            GetInfoAboutDecks();
        }

        public void GetInfoAboutDecks()
        {
            Debug.Log($"Cards in EventDeck: {m_eventCards.Count}\nCards in ResourceDeck: {m_resourceCards.Count}");
            foreach(var card in m_eventCards)
            {
                Debug.Log($"Card: {((EventCard)card).CardInfo}");
            }
            foreach(var card in m_resourceCards)
            {
                Debug.Log($"Card: {((ResourceCard)card).CardInfo}");
            }
        }

        public void GiveEventCard(Player player)
        {
            if(m_eventCards.Count > 0)
                player.PlayerDeck.AddEventCard(m_eventCards.Pop());
        }

        public void GiveResourceCard(Player player)
        {
            if (m_resourceCards.Count > 0)
                player.PlayerDeck.AddResourceCard(m_resourceCards.Pop());
        }
    }
}
