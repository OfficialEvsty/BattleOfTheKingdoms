using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using BattleOfKingdoms.EventSystems;

namespace BattleOfKingdoms.Game.Entities
{
    [RequireComponent(typeof(PhotonView))]
    public class VirtualLeader : MonoBehaviourPunCallbacks, IGameEventObserver<PlayerInstantiateEvent>
    {
        [Header("Prefab игрока")]
        [SerializeField] private Player _playerPrefabs;
        [Header("Кол-во игроков")]
        [Header("Список позиций спавна игроков")]
        [SerializeField] private List<Transform> SpawnPointPlayer = new List<Transform>();
        //private Dictionary<string, Player> m_playerByUserIDs = new Dictionary<string, Player>();
        private PhotonView m_photonView;
        private Player _currentPlayer;
        private Queue<Player> PlayersQueue = new Queue<Player>();
        //private PhotonView m_photonView;

        private Player currentQueuePlayer;

        private void Awake()
        {
            GameEventSystem.AddEventObserver(this);
        }
        private void Start()
        {

            //m_photonView = GetComponent<PhotonView>();
            Initalize();
            //AddPlayer();
            if (PhotonNetwork.LocalPlayer.IsMasterClient)
                StartNextPlayerTurn();
        }

        /*private void AddPlayer()
        {
            foreach(var playerByID in m_playerByUserIDs)
            {
                _currentPlayer = playerByID.Value;
                _currentPlayer.gameObject.name = $"Player ({playerByID.Key})";                
                PlayersQueue.Enqueue(_currentPlayer.GetComponent<Player>());
            }                           
        }*/


        private void Update()
        {

        }
        
        [PunRPC]
        private void StartNextPlayerTurn()
        {
            currentQueuePlayer = PlayersQueue.Dequeue();
            currentQueuePlayer.EndTurnEvent += OnEndPlayerTurn;
            currentQueuePlayer.StartTurn();
            PlayerStep(currentQueuePlayer.HasTurn);
        }

        private void OnEndPlayerTurn()
        {
            currentQueuePlayer.EndTurnEvent -= OnEndPlayerTurn;
            PlayersQueue.Enqueue(currentQueuePlayer);
            StartNextPlayerTurn();
        }

        private void PlayerStep(bool step)
        {
            foreach(var player in PlayersQueue)
            {
                Debug.Log($"Player.ID: {player}");
            }
            if (step)
            {
                Debug.Log("Ходит " + currentQueuePlayer.name);
            }
        }

        public void OnChangeQQ()
        {
            StartNextPlayerTurn();
        }

        private void OnDestroy()
        {
            GameEventSystem.RemoveEventObserver(this);
        }



        private void Initalize()
        {
            Player player
                = PhotonNetwork.Instantiate("Prefab/" + _playerPrefabs.name, SpawnPointPlayer[UnityEngine.Random.Range(0, 8)].position, Quaternion.identity).GetComponent<Player>();
            m_photonView = player.GetComponent<PhotonView>();
            if(!PhotonNetwork.IsMasterClient)
                this.photonView.RPC("RPC_UpdateDictPlayerByIDs", RpcTarget.MasterClient);  
        }

        [PunRPC]
        public void RPC_UpdateDictPlayerByIDs(PhotonMessageInfo info)
        {
            if (PhotonNetwork.IsMasterClient)
            {                
                Debug.Log($"{info.Sender.UserId} was added to Dict");
            }
        }

        public void OnGameEvent(PlayerInstantiateEvent gameEvent)
        {
            PlayersQueue.Enqueue(gameEvent.player);
            
            if(PlayersQueue.Count == PhotonNetwork.PlayerList.Length)
            {
                Debug.Log("The game start");
            }
        }

        /*public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                stream.Serialize()
            }
        }*/
    }
}
