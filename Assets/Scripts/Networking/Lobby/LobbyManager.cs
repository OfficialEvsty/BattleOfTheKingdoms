using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using UnityEngine.Events;

namespace BattleOfKingdoms.Networking
{
    public class LobbyManager : MonoBehaviour
    {
        public UnityEvent OnReadyEvent;

        public void Exit()
        {
            SceneManager.LoadScene("Menu");
            PhotonNetwork.LeaveRoom();
        }

        public void OnReadyClick()
        {
            PlayerHolder playerHolder = UILobbyManager.LocalPlayer;
            if (!playerHolder.IsReady)
            {
                playerHolder.IsReady = true;
            }
            else
            {
                playerHolder.IsReady = false;
            }
            OnReadyEvent?.Invoke();
        }

        public void OnStartGameClick()
        {
            bool isReadyStartGame = UILobbyManager.IsReadyStart;
            if (PhotonNetwork.LocalPlayer.IsMasterClient && isReadyStartGame)
            {
                PhotonNetwork.CurrentRoom.IsOpen = false;
                PhotonNetwork.CurrentRoom.IsVisible = false;
                PhotonNetwork.LoadLevel("Game");
                Debug.Log("StartGame");
            }
                

            else
                Debug.Log("Cannot start the game");
        }
    }
}
