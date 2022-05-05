using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Photon.Pun;
using BattleOfKingdoms.EventSystems;
using System.Linq;

namespace BattleOfKingdoms.Game.Entities
{
    [RequireComponent(typeof(PhotonView))]
    public class VirtualLeader : MonoBehaviourPunCallbacks, IGameEventObserver<PlayerInstantiateEvent>
    {
        [Header("Prefab игрока")]
        [SerializeField] private Player _playerPrefabs;
        [Header("Кол-во игроков")]
        [Header("Список позиций спавна игроков")]
        [SerializeField] private List<Transform> m_playerSpawnPoints= new List<Transform>();
        [SerializeField] private List<Kingdom> m_kingdomsList = new List<Kingdom>();
        [SerializeField] private Deck m_deck;
        [SerializeField] private TMP_Text m_currentPlayerInTurn;
        private Dictionary<Transform, Player> m_spawnedPlayers = new Dictionary<Transform, Player>();
        private List<Transform> m_availablePositions;
        private Player currentQueuePlayer;
        public Queue<Player> PlayersQueue = new Queue<Player>();

        private void Awake()
        {
            GameEventSystem.AddEventObserver(this);            
        }
        private void Start()
        {            
            Initalize();            
        }
        
        private void StartNextPlayerTurn()
        {
            
            currentQueuePlayer = PlayersQueue.Peek();
            
            currentQueuePlayer.EndTurnEvent += OnEndPlayerTurn;
            currentQueuePlayer.StartTurn();
            
            PlayerStep(currentQueuePlayer.HasTurn);

            m_currentPlayerInTurn.text = "Turn: " + currentQueuePlayer.NickName;
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
                m_deck.GiveResourceCard(currentQueuePlayer);
                m_deck.GiveEventCard(currentQueuePlayer);
                Debug.Log("Ходит " + currentQueuePlayer.name);
            }
                       
        }
        [PunRPC]
        private void SetPlayerPosition(int viewID)
        {
            
            if (m_availablePositions == null)
            {
                m_availablePositions = new List<Transform>(m_playerSpawnPoints);
            }
            int positionIndex = UnityEngine.Random.Range(0, m_availablePositions.Count);
            var view = PhotonView.Find(viewID);
            view.RPC("SetPosition", RpcTarget.All, m_availablePositions[positionIndex].position);
            m_availablePositions.RemoveAt(positionIndex);
        }

        private void OnPlayerPositionChanged(Player sender, Vector3 position)
        {
            var playerTransform = m_playerSpawnPoints.FirstOrDefault(x => x.position == sender.transform.position);
            m_spawnedPlayers[playerTransform] = sender;
            if(m_spawnedPlayers.Count == PhotonNetwork.PlayerList.Length)
            {
                foreach (var playerSpawnPoint in m_playerSpawnPoints)
                {
                    if (!m_spawnedPlayers.ContainsKey(playerSpawnPoint))
                        continue;
                    PlayersQueue.Enqueue(m_spawnedPlayers[playerSpawnPoint]);
                }
                StartNextPlayerTurn();
            }
            sender.PositionChangedEvent -= OnPlayerPositionChanged;
        }

        private void OnDestroy()
        {
            GameEventSystem.RemoveEventObserver(this);
        }

        private void Initalize()
        {            
            PhotonNetwork
                .Instantiate("Prefab/GameEntitiesPrefab/" + _playerPrefabs.name, m_playerSpawnPoints[UnityEngine.Random.Range(0, 8)].position, Quaternion.identity).GetComponent<Player>();            

        }

        public void OnGameEvent(PlayerInstantiateEvent gameEvent)
        {
            gameEvent.player.PositionChangedEvent += OnPlayerPositionChanged;
            photonView.RPC("SetPlayerPosition", RpcTarget.MasterClient, gameEvent.player.photonView.ViewID);
        }
    }
}
