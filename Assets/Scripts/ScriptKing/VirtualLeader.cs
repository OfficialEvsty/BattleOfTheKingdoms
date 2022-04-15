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

        private Player currentQueuePlayer;
        public Queue<Player> PlayersQueue = new Queue<Player>();

        private void Awake()
        {
            GameEventSystem.AddEventObserver(this);
        }
        private void Start()
        {
            Initalize();
            StartNextPlayerTurn();
        }
        
        private void StartNextPlayerTurn()
        {
            
            currentQueuePlayer = PlayersQueue.Peek();
            
            currentQueuePlayer.EndTurnEvent += OnEndPlayerTurn;
            currentQueuePlayer.StartTurn();
            
            PlayerStep(currentQueuePlayer.HasTurn);
        }

        public void OnEndPlayerTurn()
        {            
            currentQueuePlayer.EndTurnEvent -= OnEndPlayerTurn;
            
            PlayersQueue.Dequeue();
            PlayersQueue.Enqueue(currentQueuePlayer);
            
            currentQueuePlayer = null;
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

        private void OnDestroy()
        {
            GameEventSystem.RemoveEventObserver(this);
        }

        private void Initalize()
        {
            PhotonNetwork
                .Instantiate("Prefab/" + _playerPrefabs.name, SpawnPointPlayer[UnityEngine.Random.Range(0, 8)].position, Quaternion.identity).GetComponent<Player>().gameObject.name = PhotonNetwork.LocalPlayer.NickName;            
        }

        public void OnGameEvent(PlayerInstantiateEvent gameEvent)
        {
            PlayersQueue.Enqueue(gameEvent.player);
            
            if(PlayersQueue.Count == PhotonNetwork.PlayerList.Length)
            {
                Debug.Log("The game start");
            }
        }
    }
}
