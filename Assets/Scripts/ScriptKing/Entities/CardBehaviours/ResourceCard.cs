using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleOfKingdoms.Game.Entities;
using UnityEngine.Events;

namespace BattleOfKingdoms.Game.Cards
{
    [RequireComponent(typeof(UIShowerResourceCardInfo))]
    [RequireComponent(typeof(BoxCollider))]
    [RequireComponent(typeof(Rigidbody))]
    public class ResourceCard : MonoBehaviour, ICardResource
    {
        [SerializeField] private CardResourceScriptableObject m_cardResourceSO;
        public CardResourceScriptableObject CardInfo { get { return m_cardResourceSO; } }
        public static System.Action<ResourceType, int> ResourceIncreasedEvent { get; set; }  

        private UIShowerResourceCardInfo m_uiShower;

        public ResourceCard(CardResourceScriptableObject resCardType)
        {
            m_cardResourceSO = resCardType;            
        }

        private void Awake()
        {
            m_uiShower = GetComponent<UIShowerResourceCardInfo>();
        }

        private void Start()
        {            
            m_uiShower.SetInfo(m_cardResourceSO);
        }

        public void SetCardInfo(CardResourceScriptableObject cardInfoSO)
        {
            m_cardResourceSO = cardInfoSO;
        }

        public void ApplyResourceCard(Kingdom targetKingdom)
        {
            ResourceIncreasedEvent?.Invoke(m_cardResourceSO.CardType, m_cardResourceSO.Count);
            Debug.Log("Карта ресурсов применена");
        }
    }
}
