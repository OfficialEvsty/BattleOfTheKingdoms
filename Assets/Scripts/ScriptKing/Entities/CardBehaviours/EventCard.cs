using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleOfKingdoms.Game.Entities;

namespace BattleOfKingdoms.Game.Cards
{
    public class EventCard : MonoBehaviour, ICardEvent
    {
        [SerializeField] private CardEventScriptableObject m_cardEventSO;
        public CardEventScriptableObject CardInfo { get { return m_cardEventSO; } }

        private UIShowerEventCardInfo m_uiShower;

        public EventCard(CardEventScriptableObject eventCardType)
        {
            m_cardEventSO = eventCardType;
        }

        private void Awake()
        {
            m_uiShower = GetComponent<UIShowerEventCardInfo>();
        }

        private void Start()
        {
            m_uiShower.SetInfo(m_cardEventSO);
        }

        public void SetCardInfo(CardEventScriptableObject cardInfoSO)
        {
            m_cardEventSO = cardInfoSO;
        }

        public void ApplyEventCard(Kingdom targetKingdom)
        {
            foreach(var effect in m_cardEventSO.Effects)
            {
                effect.Apply(targetKingdom);
            }
            Debug.Log($"Карта события применена на {targetKingdom}");
        }
    }
}
