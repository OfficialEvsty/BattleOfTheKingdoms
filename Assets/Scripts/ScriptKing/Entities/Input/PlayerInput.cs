using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BattleOfKingdoms.Game.Inputs;
using Photon.Pun;

namespace BattleOfKingdoms.Game.Entities
{
    [RequireComponent(typeof(SelectionManager))]
    public class PlayerInput : MonoBehaviourPunCallbacks
    {
        private ButtonPressListener m_buttonPressListener;
        private Camera m_playerCamera;
        private List<IUpdateDependent> m_updateDependents = new List<IUpdateDependent>();
        private SelectionManager m_selectionManager;
        public TurnControls TurnControls { get; private set; }
        public MovementsInput MovementsInput { get; private set; }

        public KeyCode PickUpKey = KeyCode.E;
        public KeyCode ThrowKey = KeyCode.Q;


        private void Awake()
        {
            m_buttonPressListener = FindObjectOfType<ButtonPressListener>();
            m_playerCamera = FindObjectOfType<Camera>();
            TurnControls = new TurnControls(m_buttonPressListener);
            MovementsInput = new MovementKeyBoard(transform);
            
            m_updateDependents.AddRange(new List<IUpdateDependent> { TurnControls, MovementsInput });
            m_selectionManager = GetComponent<SelectionManager>();
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

            SendEventsToListeners();
            Debug.Log($"Отловил {m_selectionManager.SelectedTarget}");
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
                m_playerCamera.GetComponent<CameraPlayerTracking>().Target = transform.Find("Head");
            }
        }
        private void SendEventsToListeners()
        {
            CatchEscapeClick();
            CatchPickUpClick();
            CatchThrowClick();

            SendMouseTrack();
        }

        private void SendMouseTrack()
        {
            var mouseTrack = ((MovementKeyBoard)MovementsInput).MouseTrack;
            if (System.Math.Abs(mouseTrack) > 0)
                OnClickActionsHolder.MoveTrackEvent?.Invoke(mouseTrack);
        }

        private void CatchEscapeClick()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OnClickActionsHolder.EscapeClickEvent?.Invoke();
            }
        }

        private void CatchPickUpClick()
        {
            Transform target = m_selectionManager.SelectedTarget;
            if (Input.GetKeyDown(PickUpKey) && target)
            {
                OnClickActionsHolder.PickUpClickEvent?.Invoke(target);
            }
        }

        private void CatchThrowClick()
        {
            if (Input.GetKeyDown(ThrowKey))
            {
                OnClickActionsHolder.ThrowOutClickEvent?.Invoke();
            }
        }
    }
}
