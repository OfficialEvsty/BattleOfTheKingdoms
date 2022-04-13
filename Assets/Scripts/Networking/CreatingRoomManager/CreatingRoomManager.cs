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

        /// <summary>
        /// ������� �������/�����.
        /// </summary>
        public void CreateRoom()
        {
            PhotonNetwork.CreateRoom(s_nameInputField.text);
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
