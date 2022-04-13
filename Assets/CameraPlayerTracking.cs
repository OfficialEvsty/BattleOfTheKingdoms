using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleOfKingdoms.Game.Entities
{
    public class CameraPlayerTracking : MonoBehaviour
    {
        public Transform Target;
        [SerializeField] private Vector3 m_offset;

        private void FollowPlayer()
        {            
            if(Target != null)
                transform.position = Target.position + m_offset;           
        }

        private void LateUpdate()
        {
            FollowPlayer();
        }
    }
}
