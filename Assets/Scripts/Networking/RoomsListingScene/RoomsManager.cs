using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;

namespace BattleOfKingdoms.Networking
{
    public class RoomsManager : MonoBehaviourPunCallbacks
    {
        [SerializeField] private InputField s_nameInputField;
        public void JoinRoom()
        {
            if (s_nameInputField.text == "")
            {
                PhotonNetwork.JoinRoom(UIShowRooms.Instance.SelectedRoom);
            }
            else
            {
                PhotonNetwork.JoinRoom(s_nameInputField.text);
            }
        }

        public override void OnJoinedRoom()
        {
            PhotonNetwork.LoadLevel("Lobby");
        }

        public void OnBackMenuClick()
        {
            CustomSceneManager.ChangeScene(1);
        }
    }
}
