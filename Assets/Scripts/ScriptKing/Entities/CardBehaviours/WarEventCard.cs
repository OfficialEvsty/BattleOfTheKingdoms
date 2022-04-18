using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleOfKingdoms.Game.Entities;

namespace BattleOfKingdoms.Game.Cards
{
    [RequireComponent(typeof(UIShowerEventCardInfo))]
    public class WarEventCard : MonoBehaviour, ICardEvent
    {
        [SerializeField] private CardEventScriptableObject m_cardEventSO;
        private UIShowerEventCardInfo m_uiShower;
        private EventCardType m_eventCardType = EventCardType.War;
        public EventCardType EventCardType { get { return m_eventCardType; } }

        private void Awake()
        {
            m_uiShower = GetComponent<UIShowerEventCardInfo>();
            m_cardEventSO = Resources.Load<CardEventScriptableObject>("Prefab/ScriptableObjects/EventCards/WarEventCard");
            m_uiShower.SetInfo(m_cardEventSO);
        }
        public void ApplyEventCard(/*Kingdom targetKingdom*/)
        {
            Debug.Log("Карта войны применена");
        }
    }
}
