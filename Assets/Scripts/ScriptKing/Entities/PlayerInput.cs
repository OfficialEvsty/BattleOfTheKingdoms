using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BattleOfKingdoms.Game.Inputs;
using Photon.Pun;

namespace BattleOfKingdoms.Game.Entities
{
    public class PlayerInput : MonoBehaviourPunCallbacks
    {
        private ButtonPressListener m_buttonPressListener;
        private Camera m_playerCamera;
        private List<IUpdateDependent> m_updateDependents = new List<IUpdateDependent>();
        public TurnControls TurnControls { get; private set; }
        public MovementsInput MovementsInput { get; private set; }


        private void Awake()
        {
            m_buttonPressListener = FindObjectOfType<ButtonPressListener>();
            m_playerCamera = FindObjectOfType<Camera>();
            TurnControls = new TurnControls(m_buttonPressListener);
            MovementsInput = new MovementKeyBoard(transform);
            m_updateDependents.AddRange(new List<IUpdateDependent> { TurnControls, MovementsInput });
        }

        private void Start()
        {
            SetCameraTarget();
        }

        private void Update()
        {
            if (photonView.IsMine)
            {
                foreach (var updateDependent in m_updateDependents)
                {
                    updateDependent.OnUpdate();
                }
            }

            CatchEscapeClick();
        }

        private void OnDestroy()
        {
            Debug.Log("Событие на кнопки уничтожилось");
            TurnControls.OnInputDestroy();
        }

        private void SetCameraTarget()
        {
            if (gameObject.GetComponent<PhotonView>().IsMine)
            {
                m_playerCamera.GetComponent<CameraPlayerTracking>().Target = transform;
            }
        }

        private void CatchEscapeClick()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OnClickActionsHolder.EscapeClickEvent?.Invoke();
            }
        }
    }
}
