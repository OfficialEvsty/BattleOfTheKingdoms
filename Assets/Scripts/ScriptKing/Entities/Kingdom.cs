using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleOfKingdoms.Game.Entities
{
    public abstract class Kingdom
    {
        protected List<IEffect> m_effectsList = new List<IEffect>();
        protected Dictionary<Resource, int> m_resourcesDict = new Dictionary<Resource, int>();
        public List<Kingdom> FriendlyKingdoms = new List<Kingdom>();

        protected void PutEffect(IEffect applyEffect)
        {

        }
        protected void IncreaseResource(Resource resource, int count)
        {

        }
    }
}
