using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using TMPro;
using UnityEngine.UI;

namespace BattleOfKingdoms.Networking
{
    public class MenuManager : MonoBehaviourPunCallbacks
    {
        [SerializeField] private TMP_InputField nicknameInputField;
        private string s_defaultPlaceholderText = "Call your name";

        private void Start()
        {
            TextMeshProUGUI placeholder = (TextMeshProUGUI)nicknameInputField.placeholder;
            placeholder.text = (PhotonNetwork.NickName != "") ? PhotonNetwork.NickName : s_defaultPlaceholderText;
        }

        public void OnCreatedRoomClick()
        {
            CustomSceneManager.ChangeScene(3);
        }

        public void OnJoinedRoomClick()
        {
            CustomSceneManager.ChangeScene(2);
        }

        public void OnAcceptNickname()
        {
            PhotonNetwork.NickName = nicknameInputField.text;
        }
    }
}
