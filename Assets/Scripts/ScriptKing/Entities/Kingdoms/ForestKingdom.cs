using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleOfKingdoms.Game.Entities
{
    public class ForestKingdom : Kingdom
    {
        private void Start()
        {
            m_resourcesDict[ResourceType.Wood] = 5;
        }
        private void Update()
        {
            Debug.Log($"Resource Wood: {m_resourcesDict[ResourceType.Wood]}");
        }
    }
}

