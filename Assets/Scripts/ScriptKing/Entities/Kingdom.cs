using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleOfKingdoms.Game.Cards;
using System;

namespace BattleOfKingdoms.Game.Entities
{
    public enum ResourceType
    {
        Wood,
        Stone,
        Iron_Ore,
        Gold_Ore
    }
    public abstract class Kingdom : MonoBehaviour
    {
        protected List<Effect> m_effectsList = new List<Effect>();
        protected Dictionary<ResourceType, int> m_resourcesDict;
        public List<Kingdom> FriendlyKingdoms = new List<Kingdom>();

        protected void Awake()
        {
            m_resourcesDict = new Dictionary<ResourceType, int>();
            ResourceCard.ResourceIncreasedEvent += OnResourceCardApplied;
            Effect.ReduceResourceEvent += OnReduceResource;
        }

        protected void OnDestroy()
        {
            ResourceCard.ResourceIncreasedEvent -= OnResourceCardApplied;
        }

        protected void PutEffect(Effect applyEffect)
        {
            if(applyEffect.Duration > 0)
                m_effectsList.Add(applyEffect);
        }
        protected void IncreaseResource(ResourceType resource, int count)
        {
            m_resourcesDict[resource] = count;

        }

        protected void DeacreaseResource(ResourceType resource, int count)
        {
            if (m_resourcesDict[resource] < count)
                m_resourcesDict[resource] = 0;
            else
                m_resourcesDict[resource] -= count;
        }

        public void OnResourceCardApplied(ResourceType resCardType, int count)
        {
            IncreaseResource(resCardType, count);
        }

        public void OnReduceResource(ResourceType resType, int count)
        {
            DeacreaseResource(resType, count);
        }
    }
}
