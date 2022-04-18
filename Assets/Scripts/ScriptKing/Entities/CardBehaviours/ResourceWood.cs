using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleOfKingdoms.Game.Entities;

namespace BattleOfKingdoms.Game.Cards
{
    [RequireComponent(typeof(UIShowerResourceCardInfo))]
    public class ResourceWood : MonoBehaviour, ICardResource
    {
        private ResourceCardType resourceCardType = ResourceCardType.Wood;
        public ResourceCardType ResourceCardType { get { return resourceCardType; } }
        public void ApplyResourceCard(Kingdom targetKingdom)
        {
            Debug.Log("Карта ресурсов применена");
        }
    }
}
