using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace BattleOfKingdoms.Networking
{
    /// <summary>
    /// Данный класс обновляет и чистит информацию о доступных комнатах.
    /// </summary>
    public class UpdaterListRoom : MonoBehaviourPunCallbacks
    {
        /// <summary>
        /// Данный приватный словарь хранит ключи имён комнат и в качестве значения представляет тип RoomInfo.
        /// </summary>
        private static Dictionary<string, RoomInfo> _cashedRoomList = new Dictionary<string, RoomInfo>();

        /// <summary>
        /// Геттерное свойство для приватного словаря комнат.
        /// </summary>
        public static Dictionary<string, RoomInfo> RoomList { get { return _cashedRoomList; } }

        private static bool isActive;
        private void Awake()
        {
            if (!isActive)
                DontDestroyOnLoad(gameObject);
            else
                Destroy(gameObject);
            isActive = true;
        }

        /// <summary>
        /// Данный приватный метод записывает информацию о доступных комнатах в словарь.
        /// </summary>
        /// <param name="roomList"></param>
        private void UpdateListRoom(List<RoomInfo> roomList)
        {
            for (int i = 0; i < roomList.Count; i++)
            {
                RoomInfo info = roomList[i];

                if (info.RemovedFromList)
                {
                    _cashedRoomList.Remove(info.Name);
                }
                else
                {
                    _cashedRoomList[info.Name] = info;
                }
                Debug.Log("Room: " + info.Name);
            }
        }

        /// <summary>
        /// (Переопределено) Данное событие очищает словарь, когда игрок заходит в лобби.
        /// </summary>
        public override void OnJoinedLobby()
        {
            Debug.Log("Lobby is " + PhotonNetwork.InLobby);
        }

        /// <summary>
        /// (Переопределено) Данное событие позволяет обновлять инормацию о текущих доступных комнатах.
        /// </summary>
        /// <param name="roomInfo"></param>

        public override void OnRoomListUpdate(List<RoomInfo> roomInfo)
        {
            UpdateListRoom(roomInfo);
        }

        /// <summary>
        /// (Переопределено) Данное событие чистит словарь с комнатами, когда игрок выходит из лобби.
        /// </summary>
        public override void OnLeftLobby()
        {
            _cashedRoomList.Clear();
        }

        /// <summary>
        /// (Переопределено) Данное событие чистит словарь с комнатами, когда игрок отключается от игры.
        /// </summary>
        /// <param name="cause"></param>
        public override void OnDisconnected(DisconnectCause cause)
        {
            _cashedRoomList.Clear();
        }
    }
}
