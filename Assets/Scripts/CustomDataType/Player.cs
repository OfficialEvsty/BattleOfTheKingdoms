using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;
using UnityEngine.Events;
using System;
using BattleOfKingdoms.EventSystems;

namespace BattleOfKingdoms.Game.Entities
{
    [RequireComponent(typeof(PlayerInput))]
    public class Player : MonoBehaviour
    {
        private RaycastHit m_hit;
        private PlayerInput m_playerInput;
        private Camera m_playerCamera;
        public event System.Action EndTurnEvent;

        private NavMeshAgent m_navMeshAgent;
        public bool HasTurn { get; private set; }


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
            if (m_playerInput.TurnControls.EndTurnPressed && HasTurn)
                EndTurn();
        }

        private void LateUpdate()
        {
        }


        public void StartTurn()
        {
            HasTurn = true;
            m_playerInput.TurnControls.IsEnabled = true;
        }

        private void EndTurn()
        {
            if (HasTurn)
            {
                EndTurnEvent?.Invoke();
                HasTurn = false;
                m_playerInput.TurnControls.IsEnabled = false;
            }
        }

        private void SetCameraTarget()
        {
            if (gameObject.GetComponent<PhotonView>().IsMine)
            {
                m_playerCamera.GetComponent<CameraPlayerTracking>().Target = transform;
            }
        }

        /*public static byte[] Serialize(object obj)
        {
            var player = (Player)obj;
            //HasTurn
            byte[] myPlayerBytes = new byte[1];
            myPlayerBytes[0] = (player.HasTurn) ? (byte)1 : (byte)0 ;
            return myPlayerBytes;
        }

        public static object Deserialize(byte[] bytes)
        {
            Player player = new Player();
            //HasTurn
            player.HasTurn = BitConverter.ToBoolean(bytes, 0);
            return player;
        }*/
    }
}
