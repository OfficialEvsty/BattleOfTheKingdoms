using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleOfKingdoms.Game.Cards;

namespace BattleOfKingdoms.Game.Entities
{
    [CreateAssetMenu(fileName = "new SpawnerCards", menuName = "GameAssets/SpawnerCards", order = 53)]
    public class SpawnCards : ScriptableObject
    {
        [SerializeField] private GameObject m_eventCardPrefab;
        [SerializeField] private GameObject m_resourceCardPrefab;
        private Transform m_posToSpawnCards;
        private float f_xAxis = 0;

        public void InitializeSpawnCardsPosition(Transform posToSpawnCards)
        {
            m_posToSpawnCards = posToSpawnCards;
        }        

        public ICardEvent SpawnEventCard(ICardEvent cardEv)
        {
            Vector3 offset = new Vector3(f_xAxis, 0, 0);
            EventCardType typeCard = cardEv.EventCardType;
            GameObject cardEvent = Instantiate(m_eventCardPrefab, m_posToSpawnCards);
            cardEvent.transform.position += offset;
            f_xAxis += 0.5f;
            AddSpecifyEventComponent(cardEvent, typeCard);
            return cardEvent.GetComponent<ICardEvent>();
        }

        public ICardResource SpawnResourceCard(ICardResource cardRes)
        {
            ICardResource cardResource = Instantiate(m_resourceCardPrefab, m_posToSpawnCards).GetComponent<ICardResource>();
            
            return cardResource;
        }

        private bool AddSpecifyEventComponent(GameObject cardEvent, EventCardType type)
        {
            switch (type)
            {
                case EventCardType.War:
                    cardEvent.AddComponent<WarEventCard>();
                    return true;
                case EventCardType.Peace:
                    cardEvent.AddComponent<PeaceEvent>();
                    return true;
                default:
                    return false;
            }
        }

        private bool AddSpecifyResourceComponent(GameObject cardRes, ResourceCardType type)
        {
            switch (type)
            {
                case ResourceCardType.Wood:
                    cardRes.AddComponent<ResourceWood>();
                    return true;
                default:
                    return false;
            }
        }
    }
}
