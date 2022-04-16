using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleOfKingdoms.Game.Entities;

namespace BattleOfKingdoms.Game.Cards
{
    public class WarEventCard : MonoBehaviour, ICardEvent
    {
        [SerializeField] private CardEventScriptableObject m_cardEventSO;
        public CardEventScriptableObject CardInfo { get { return m_cardEventSO; } }
        public void ApplyEventCard(/*Kingdom targetKingdom*/)
        {
            Debug.Log("Карта войны применена");
        }
    }
}
