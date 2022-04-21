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
        private float f_xAxis = -2;

        public void InitializeSpawnCardsPosition(Transform posToSpawnCards)
        {
            m_posToSpawnCards = posToSpawnCards;
        }

        public ICardEvent SpawnEventCard(ICardEvent cardEv)
        {
            CardEventScriptableObject cardEventInfoSO = ((EventCard)cardEv).CardInfo;
            Vector3 offset = new Vector3(f_xAxis, 0, 0);
            GameObject cardEvent = Instantiate(m_eventCardPrefab, m_posToSpawnCards);
            cardEvent.transform.position += offset;
            cardEvent.AddComponent<EventCard>();
            cardEvent.GetComponent<EventCard>().SetCardInfo(cardEventInfoSO);
            f_xAxis += 0.5f;
            return cardEvent.GetComponent<ICardEvent>();
        }

        public ICardResource SpawnResourceCard(ICardResource cardRes)
        {
            CardResourceScriptableObject cardResourceInfoSO = ((ResourceCard)cardRes).CardInfo;
            Vector3 offset = new Vector3(f_xAxis, 0, 0);
            GameObject cardResource = Instantiate(m_resourceCardPrefab, m_posToSpawnCards);
            cardResource.transform.position += offset;
            cardResource.AddComponent<ResourceCard>();
            cardResource.GetComponent<ResourceCard>().SetCardInfo(cardResourceInfoSO);
            f_xAxis += 0.5f;
            return cardResource.GetComponent<ICardResource>();
        }
    }
}
