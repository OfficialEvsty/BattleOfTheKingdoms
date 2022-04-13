using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace BattleOfKingdoms.Networking
{
    /// <summary>
    /// ������ ����� ��������� � ������ ���������� � ��������� ��������.
    /// </summary>
    public class UpdaterListRoom : MonoBehaviourPunCallbacks
    {
        /// <summary>
        /// ������ ��������� ������� ������ ����� ��� ������ � � �������� �������� ������������ ��� RoomInfo.
        /// </summary>
        private static Dictionary<string, RoomInfo> _cashedRoomList = new Dictionary<string, RoomInfo>();

        /// <summary>
        /// ��������� �������� ��� ���������� ������� ������.
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
        /// ������ ��������� ����� ���������� ���������� � ��������� �������� � �������.
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
        /// (��������������) ������ ������� ������� �������, ����� ����� ������� � �����.
        /// </summary>
        public override void OnJoinedLobby()
        {
            Debug.Log("Lobby is " + PhotonNetwork.InLobby);
        }

        /// <summary>
        /// (��������������) ������ ������� ��������� ��������� ��������� � ������� ��������� ��������.
        /// </summary>
        /// <param name="roomInfo"></param>

        public override void OnRoomListUpdate(List<RoomInfo> roomInfo)
        {
            UpdateListRoom(roomInfo);
        }

        /// <summary>
        /// (��������������) ������ ������� ������ ������� � ���������, ����� ����� ������� �� �����.
        /// </summary>
        public override void OnLeftLobby()
        {
            _cashedRoomList.Clear();
        }

        /// <summary>
        /// (��������������) ������ ������� ������ ������� � ���������, ����� ����� ����������� �� ����.
        /// </summary>
        /// <param name="cause"></param>
        public override void OnDisconnected(DisconnectCause cause)
        {
            _cashedRoomList.Clear();
        }
    }
}
