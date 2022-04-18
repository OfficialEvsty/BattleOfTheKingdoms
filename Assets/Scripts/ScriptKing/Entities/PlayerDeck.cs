using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleOfKingdoms.Game.Cards;

namespace BattleOfKingdoms.Game.Entities
{
    public class PlayerDeck : MonoBehaviour
    {        
        [SerializeField] private SpawnCards m_spawnCards;        

        private List<ICardEvent> m_eventCards = new List<ICardEvent>();
        private List<ICardResource> m_resourceCards = new List<ICardResource>();

        private void Awake()
        {
            m_spawnCards.InitializeSpawnCardsPosition(transform);
        }
        public void AddEventCard(ICardEvent cardEvent)
        {
            Debug.Log($"Card:{cardEvent.EventCardType} was added");
            m_eventCards.Add(m_spawnCards.SpawnEventCard(cardEvent));
        }

        public void AddResourceCard(ICardResource cardResource)
        {
            Debug.Log($"Card:{cardResource.ResourceCardType} was added");
            m_resourceCards.Add(m_spawnCards.SpawnResourceCard(cardResource));
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
