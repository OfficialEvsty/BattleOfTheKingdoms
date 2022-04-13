using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;

namespace BattleOfKingdoms.Networking
{
    public class UILobbyManager : MonoBehaviourPunCallbacks
    {
        [SerializeField] private Transform m_parentContentHolder;
        private PlayerHolder m_playerHolder;
        private static List<PlayerHolder> l_listingPlayer = new List<PlayerHolder>();
        public static PlayerHolder LocalPlayer
        {
            get
            {
                foreach (var player in l_listingPlayer)
                {
                    if (player.Player == PhotonNetwork.LocalPlayer)
                        return player;
                }
                return null;
            }
        }

        public static bool IsReadyStart { get { return IsReadyStartGame(); } }

        private void Awake()
        {
            m_playerHolder = m_parentContentHolder.Find("PlayerPrefab").GetComponent<PlayerHolder>();
            GetCurrentRoomPlayers();
            UpdateUIPlayerList();
        }

        public override void OnDisable()
        {
            base.OnDisable();
            l_listingPlayer.Clear();
        }

        private void GetCurrentRoomPlayers()
        {
            foreach (KeyValuePair<int, Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
            {
                AddPlayerInList(playerInfo.Value);
            }
        }

        private void AddPlayerInList(Player newPlayer)
        {
            PlayerHolder playerHolder = new PlayerHolder();
            playerHolder.SetPlayerInfo(newPlayer);
            l_listingPlayer.Add(playerHolder);
        }

        private void RemovePlayerFromList(Player otherPlayer)
        {
            int index = l_listingPlayer.FindIndex(x => x.Player == otherPlayer);
            if (index != -1)
            {
                l_listingPlayer.RemoveAt(index);
            }
        }

        private static bool IsReadyStartGame()
        {
            foreach (var player in l_listingPlayer)
            {
                if (player.IsReady)
                    continue;
                return false;
            }
            return true;
        }

        public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
        {
            AddPlayerInList(newPlayer);
            UpdateUIPlayerList();
        }

        public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
        {
            RemovePlayerFromList(otherPlayer);
            UpdateUIPlayerList();
        }

        [PunRPC]
        private void DeleteUIPlayerEntries()
        {
            foreach (Transform playerEntry in m_parentContentHolder)
            {
                if (!playerEntry.gameObject.activeInHierarchy) continue;
                Destroy(playerEntry.gameObject);
            }
        }

        [PunRPC]
        public void UpdateUIPlayerList()
        {
            DeleteUIPlayerEntries();

            foreach (var player in l_listingPlayer)
            {

                RectTransform rectEntryPos = Instantiate(m_playerHolder, m_parentContentHolder).GetComponent<RectTransform>();
                rectEntryPos.gameObject.SetActive(true);
                rectEntryPos.GetComponent<Image>().color = (player.Player.IsLocal) ? new Color(0, 206, 209) : Color.white;

                Transform playerBorder = rectEntryPos.transform.Find("NameBorder");
                TMP_Text playerName = playerBorder.GetComponentInChildren<TMP_Text>();
                playerName.text = player.Player.NickName;

                Transform playerStatus = rectEntryPos.transform.Find("Sprite_Status");
                playerStatus.GetComponent<Image>().color = (player.IsReady) ? Color.green : Color.red;
                TMP_Text playerStatusText = playerStatus.GetComponentInChildren<TMP_Text>();
                playerStatusText.text = (player.IsReady) ? "Ready" : "Not Ready";

                if (player.Player.IsMasterClient)
                {
                    Transform playerMaster = rectEntryPos.transform.Find("Sprite_Master");
                    playerMaster.gameObject.SetActive(true);
                }
            }
        }

        public void OnChangeReadyStatus_Click()
        {
            photonView.RPC("RPC_ChangeReadyStatus", RpcTarget.OthersBuffered, PhotonNetwork.LocalPlayer, LocalPlayer.IsReady);
            photonView.RPC("UpdateUIPlayerList", RpcTarget.OthersBuffered);
        }
        [PunRPC]
        private void RPC_ChangeReadyStatus(Player player, bool ready)
        {
            int index = l_listingPlayer.FindIndex(x => x.Player == player);
            if (index != -1)
                l_listingPlayer[index].IsReady = ready;
        }
    }
}
