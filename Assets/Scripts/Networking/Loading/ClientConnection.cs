using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using Photon.Realtime;

namespace BattleOfKingdoms.Networking
{
    public class ClientConnection : MonoBehaviourPunCallbacks
    {
        /// <summary>
        /// Данное приватное поле хранит информацию о типе лобби (Рекомендуется использовать Default LobbyType).
        /// </summary>
        private TypedLobby _customLobby = new TypedLobby("defaultLobby", LobbyType.Default);

        private void Start()
        {
            CustomSceneManager.ChangeScene(0);
            
            PhotonNetwork.AutomaticallySyncScene = true;    
            PhotonNetwork.ConnectUsingSettings();
        }

        private void Awake()
        {
            PhotonNetwork.GameVersion = MasterManager.GameSettings.GameVersion;
            PhotonNetwork.NickName = MasterManager.GameSettings.NickName;
        }
        public override void OnConnectedToMaster()
        {
            PhotonNetwork.JoinLobby(_customLobby);
            //Debug.Log("Client was connect to Master.");
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            Debug.LogWarningFormat("PUN Basics Tutorial/Launcher: OnDisconnected() was called by PUN with reason {0}", cause);
        }

        public override void OnJoinedLobby()
        {
            CustomSceneManager.ChangeScene(1);
        }
    }
}
