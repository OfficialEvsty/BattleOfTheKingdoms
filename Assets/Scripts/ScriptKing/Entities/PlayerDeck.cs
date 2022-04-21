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

        private void Start()
        {
            if (m_eventCards.Count > 0)
                m_eventCards[0].ApplyEventCard(GetComponentInParent<Player>().Kingdom);
        }
        public void AddEventCard(ICardEvent cardEvent)
        {
            Debug.Log($"Card:{cardEvent} was added");
            m_eventCards.Add(m_spawnCards.SpawnEventCard(cardEvent));
        }

        public void AddResourceCard(ICardResource cardResource)
        {
            if (cardResource == null)
                return;
            Debug.Log($"Card:{cardResource} was added");
            m_resourceCards.Add(m_spawnCards.SpawnResourceCard(cardResource));  
        }                
        

        public void ApplyEventCard()
        {
            
        }

        public void ApplyResourceCard()
        {
            foreach (var card in m_resourceCards)
                card.ApplyResourceCard(GetComponentInParent<Player>().Kingdom);
        }
    }
}
