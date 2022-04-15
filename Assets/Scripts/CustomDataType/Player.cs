using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using UnityEngine.Events;
using System;
using BattleOfKingdoms.EventSystems;

namespace BattleOfKingdoms.Game.Entities
{
    [RequireComponent(typeof(PlayerInput))]
    public class Player : MonoBehaviourPunCallbacks
    {
        private RaycastHit m_hit;
        private PlayerInput m_playerInput;
        private Camera m_playerCamera;
        public event System.Action EndTurnEvent;

        private NavMeshAgent m_navMeshAgent;
        public bool HasTurn { get; set; }


        private void Awake()
        {

            GameEventSystem.IssueGameEvent(new PlayerInstantiateEvent() { player = this });
            m_playerCamera = FindObjectOfType<Camera>();
            m_playerInput = GetComponent<PlayerInput>();
            m_navMeshAgent = GetComponent<NavMeshAgent>();            
        }

        private void Start()
        {
            SetCameraTarget();
        }

        private void Update()
        {
            Debug.Log($"{photonView.ViewID} Очередь: {HasTurn} Нажал ли кнопку {m_playerInput.TurnControls.EndTurnPressed}, Его ли ViewID: {photonView.IsMine}");
            if (m_playerInput.TurnControls.EndTurnPressed && HasTurn && photonView.IsMine)
                EndTurn();
        }

        private void LateUpdate()
        {
        }


        public void StartTurn()
        {
            HasTurn = true;
            m_playerInput.TurnControls.IsEnabled = true;
            PhotonNetwork.RaiseEvent(RaiseEventManager.NOTIFY_PLAYER_TURN, HasTurn, RaiseEventOptions.Default, SendOptions.SendReliable);
        }

        private void EndTurn()
        {
            if (HasTurn)
            {                
                HasTurn = false;
                m_playerInput.TurnControls.IsEnabled = false;
                EndTurnEvent?.Invoke();
                PhotonNetwork.RaiseEvent(RaiseEventManager.NOTIFY_PLAYER_TURN, HasTurn, RaiseEventOptions.Default, SendOptions.SendReliable);
                Debug.Log("Нажал на кнопку конца хода");
            }
        }

        private void SetCameraTarget()
        {
            if (gameObject.GetComponent<PhotonView>().IsMine)
            {
                m_playerCamera.GetComponent<CameraPlayerTracking>().Target = transform;
            }
        }
    }
}
