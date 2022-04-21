using BattleOfKingdoms.Game.Entities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleOfKingdoms.Game.Cards.Behaviour
{
    [CreateAssetMenu(fileName ="new Effect", menuName ="Effects/ReduceResource", order = 54)]
    public class ReduceResourceEffect : Effect
    {
        [SerializeField] private ResourceType m_resourceType;
        [SerializeField] private int i_count;
        private void Awake()
        {
            Duration = 0;
            IsNegative = true;
        }
        public override void Apply(Kingdom targetKingdom)
        {
            ReduceResourceEvent?.Invoke(m_resourceType, i_count);
        }
    }
}

