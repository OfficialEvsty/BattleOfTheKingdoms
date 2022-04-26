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
        [SerializeField] private Kingdom m_kingdom;
        private NavMeshAgent m_navMeshAgent;
        public event System.Action EndTurnEvent;
        public event System.Action<Player, Vector3> PositionChangedEvent;

        public PlayerDeck PlayerDeck;
        public string NickName { get { return photonView.Controller.NickName; } }
        public bool HasTurn { get; set; }
        public Kingdom Kingdom { get { return m_kingdom; } }


        private void Awake()
        {

            
            PlayerDeck = GetComponentInChildren<PlayerDeck>();
            m_playerInput = GetComponent<PlayerInput>();
            m_navMeshAgent = GetComponent<NavMeshAgent>();
            GameEventSystem.IssueGameEvent(new PlayerInstantiateEvent() { player = this });
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
        [PunRPC]
        private void SetPosition(Vector3 position)
        {
            transform.position = position;
            PositionChangedEvent?.Invoke(this, position);
        }

        public void StartTurn()
        {
            HasTurn = true;
            m_playerInput.TurnControls.IsEnabled = true;
            m_playerInput.TurnControls.ChangeVisibleState();
            object[] datas = { photonView.ViewID, HasTurn};
            PhotonNetwork.RaiseEvent(RaiseEventManager.NOTIFY_PLAYER_TURN, datas, RaiseEventOptions.Default, SendOptions.SendReliable);
        }

        private void EndTurn()
        {
            if (HasTurn)
            {                
                HasTurn = false;
                m_playerInput.TurnControls.IsEnabled = false;
                m_playerInput.TurnControls.ChangeVisibleState();
                EndTurnEvent?.Invoke();
                object[] datas = { photonView.ViewID, HasTurn };
                PhotonNetwork.RaiseEvent(RaiseEventManager.NOTIFY_PLAYER_TURN, datas, RaiseEventOptions.Default, SendOptions.SendReliable);
                Debug.Log("Нажал на кнопку конца хода");
            }
        }

        
    }
}
