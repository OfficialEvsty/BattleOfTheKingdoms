using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleOfKingdoms.Game.Entities
{
    public abstract class Effect : ScriptableObject
    {
        public bool IsNegative { get; protected set; }
        public int Duration { get; protected set; }
        public static System.Action<ResourceType, int> ReduceResourceEvent;

        public abstract void Apply(Kingdom targetKingdom);        
    }
}
