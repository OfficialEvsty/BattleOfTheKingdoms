using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleOfKingdoms.Game.Inputs
{
    public class MouseInput
    {
        Vector2 m_beginPosMouse = Vector2.zero;
        float f_minRange = 5;

        public float GetMouseTrack()
        {
            float distance = 0;
            if (m_beginPosMouse != Vector2.zero)
                distance = Vector2.Distance(Input.mousePosition, m_beginPosMouse) * CalculateSignDirectionX();
            if (System.Math.Abs(distance) > f_minRange)
            {
                return distance;
            }
            return 0f;
        }

        private int CalculateSignDirectionX()
        {
            float direction = (Input.mousePosition.x - m_beginPosMouse.x);
            if (direction == 0)
                return 0;
            return (direction > 0) ? 1 : -1;
        }

        public void CatchMouseLeftClick()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                m_beginPosMouse = Input.mousePosition;
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
                m_beginPosMouse = Vector2.zero;
        }
    }
}
