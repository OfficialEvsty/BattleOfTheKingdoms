using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleOfKingdoms.Game.Inputs
{
    public class InputKeyBoardAndMouse : GeneralInput
    {
        [SerializeField] public float f_movementSpeed = 2;
        public float MouseTrack;
        private Transform m_targetTransform;
        private Transform m_headTransform;
        private Transform m_bodyTransform;
        private MouseLook m_mouseLook;
        private MouseInput m_mouseInput;
        public InputKeyBoardAndMouse(Transform targetTransform)
        {
            m_targetTransform = targetTransform;
            m_headTransform = m_targetTransform.Find("Head");
            //m_bodyTransform = m_targetTransform.Find("Body");
            m_mouseLook = new MouseLook(m_headTransform);
            m_mouseInput = new MouseInput();
        }
        protected override void UpdateMovement()
        {
            throw new System.NotImplementedException();
        }

        public override void OnUpdate()
        {
            UpdatePosition();
            UpdateRotation();
            m_mouseLook.UpdateRotation();
            m_mouseInput.CatchMouseLeftClick();
            MouseTrack = m_mouseInput.GetMouseTrack();
            Swipe = DefineSwipe(MouseTrack);
        }

        public Swipe DefineSwipe(float track)
        {
            if(track == 0)
                return Swipe.None;
            return (track > 0) ? Swipe.Right : Swipe.Left;
        }

        protected override void UpdatePosition()
        {
            /*float verticalMove = Input.GetAxis("Vertical");
            float horizontalMove = Input.GetAxis("Horizontal");

            Vector3 movement = new Vector3(horizontalMove, 0, verticalMove);
            m_bodyTransform.Translate(movement * f_movementSpeed * Time.fixedDeltaTime);*/
        }

        private float yRotation;
        protected void UpdateRotation()
        {
            //yRotation = m_headTransform.rotation.eulerAngles.y;
            //m_bodyTransform.rotation = Quaternion.Euler(0, yRotation, 0);     
        }
    }
}
