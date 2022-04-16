using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleOfKingdoms.Game.Entities;

namespace BattleOfKingdoms.Game.Cards
{
    public class ResourceWood : ICardResource
    {
        [SerializeField] private CardResourceScriptableObject m_cardResourceSO;
        public CardResourceScriptableObject CardInfo { get { return m_cardResourceSO; } }
        public void ApplyResourceCard(Kingdom targetKingdom)
        {
            Debug.Log("Карта ресурсов применена");
        }
    }
}
