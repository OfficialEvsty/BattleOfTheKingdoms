using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

namespace BattleOfKingdoms.Networking
{
    /// <summary>
    /// ���������������� ����� ��� �������� ������ � ������������� � ������������ ��������.
    /// </summary>
    public class CreatingRoomManager : MonoBehaviourPunCallbacks
    {
        [SerializeField] private InputField s_nameInputField;
        [SerializeField] private InputField s_passwordInputField;
        [SerializeField] private byte i_maxPlayersInRoom = 8;

        /// <summary>
        /// ������� �������/�����.
        /// </summary>
        public void CreateRoom()
        {
            PhotonNetwork.CreateRoom(s_nameInputField.text, new Photon.Realtime.RoomOptions() { MaxPlayers = i_maxPlayersInRoom });
        }

        /// <summary>
        /// ������������ ������ � �������.
        /// </summary>
        public void JoinRoom()
        {
            PhotonNetwork.JoinRoom(s_nameInputField.text);
        }

        /// <summary>
        /// ��������� ����� � �����, ����� ��� ������ ����� JoinRoom.
        /// </summary>
        public override void OnJoinedRoom()
        {
            SceneManager.LoadScene("Lobby");
        }

        /// <summary>
        /// ���������� � ����.
        /// </summary>
        public void OnBackMenuClick()
        {
            CustomSceneManager.ChangeScene(1);
        }
    }
}
