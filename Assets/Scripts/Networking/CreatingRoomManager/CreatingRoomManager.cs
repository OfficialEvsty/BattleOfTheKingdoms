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
    /// Пользовательский класс для создания комнат и присоединения к существующим комнатам.
    /// </summary>
    public class CreatingRoomManager : MonoBehaviourPunCallbacks
    {
        [SerializeField] private InputField s_nameInputField;
        [SerializeField] private InputField s_passwordInputField;

        /// <summary>
        /// Создает комнату/лобби.
        /// </summary>
        public void CreateRoom()
        {
            PhotonNetwork.CreateRoom(s_nameInputField.text);
        }

        /// <summary>
        /// Присоединяет клиент к комнате.
        /// </summary>
        public void JoinRoom()
        {
            PhotonNetwork.JoinRoom(s_nameInputField.text);
        }

        /// <summary>
        /// Загружает сцену с лобби, когда был вызван метод JoinRoom.
        /// </summary>
        public override void OnJoinedRoom()
        {
            SceneManager.LoadScene("Lobby");
        }

        /// <summary>
        /// Возвращает в меню.
        /// </summary>
        public void OnBackMenuClick()
        {
            CustomSceneManager.ChangeScene(1);
        }
    }
}
