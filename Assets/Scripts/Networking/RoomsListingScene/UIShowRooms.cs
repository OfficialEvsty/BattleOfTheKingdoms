using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

namespace BattleOfKingdoms.Networking
{
    public class UIShowRooms : MonoBehaviour
    {
        [SerializeField] private UpdaterListRoom m_listRoomUpdater;
        [SerializeField] private Transform m_transformContent;
        [SerializeField] private float f_offsetBtwEntries = 80;
        [SerializeField] private TMP_Text m_selectedRoom;
        private static string s_selectedRoom;
        public GameObject RoomPf;
        public string SelectedRoom { get { return s_selectedRoom; } }
        public static UIShowRooms Instance = new UIShowRooms();


        // Start is called before the first frame update
        private void OnEnable()
        {
            UIUpdateListRoom();
            m_selectedRoom.text = "Room: " + s_selectedRoom;
        }

        // Update is called once per frame
        private void Update()
        {
        }
        private void RecordRoomName(ref string roomName)
        {
            GameObject selectedEntryGameObj = EventSystem.current.currentSelectedGameObject;
            s_selectedRoom = selectedEntryGameObj.transform.Find("NameSpaceSprite").Find("Name_Text").GetComponent<TMP_Text>().text;
        }

        private void UIClearListRoom()
        {
            foreach (Transform child in m_transformContent)
            {
                if (child == RoomPf || !child.gameObject.activeInHierarchy) continue;
                Destroy(child.gameObject);
            }
        }
        public void UIUpdateListRoom()
        {
            UIClearListRoom();
            var roomDict = UpdaterListRoom.RoomList;
            foreach (var room in roomDict)
            {
                RectTransform roomRect = Instantiate(RoomPf, m_transformContent).GetComponent<RectTransform>();
                roomRect.gameObject.SetActive(true);

                TMP_Text textNameRoom = roomRect.transform.Find("NameSpaceSprite").Find("Name_Text").GetComponent<TMP_Text>();
                textNameRoom.text = room.Value.Name;

                TMP_Text textCountPlayersRoom = roomRect.transform.Find("PlayerCountSprite").Find("Count_Text").GetComponent<TMP_Text>();
                textCountPlayersRoom.text = room.Value.PlayerCount.ToString() + "/" + room.Value.MaxPlayers;
            }
            Debug.Log(UpdaterListRoom.RoomList.Count);
        }

        public void OnEntryRoomClick()
        {
            RecordRoomName(ref s_selectedRoom);
            m_selectedRoom.text = "Room: " + s_selectedRoom;
        }
    }
}
