using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleOfKingdoms.Game.Cards
{
    public class PeaceEvent : MonoBehaviour, ICardEvent
    {
        [SerializeField] private CardEventScriptableObject m_cardEventSO;
        private UIShowerEventCardInfo m_uiShower;
        private EventCardType m_eventCardType = EventCardType.Peace;
        public EventCardType EventCardType { get { return m_eventCardType; } }

        private void Awake()
        {
            m_uiShower = GetComponent<UIShowerEventCardInfo>();
            m_cardEventSO = Resources.Load<CardEventScriptableObject>("Prefab/ScriptableObjects/EventCards/PeaceEventCard");
            m_uiShower.SetInfo(m_cardEventSO);
        }
        public void ApplyEventCard(/*Kingdom targetKingdom*/)
        {
            Debug.Log("Карта мира применена");
        }
    }
}
