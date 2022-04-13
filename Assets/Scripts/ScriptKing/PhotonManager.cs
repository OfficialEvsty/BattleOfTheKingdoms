using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class PhotonManager : MonoBehaviourPunCallbacks
{

    [SerializeField] Text LogText;

    void Start()
    {
        PhotonNetwork.NickName = "Player " + Random.Range(1000, 9999);

        Log("Player name is set to " + PhotonNetwork.NickName);

        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = "1";
        PhotonNetwork.ConnectUsingSettings();

    }


    public override void OnConnectedToMaster()
    {
        Log("Connected to Master");
    }

    public void CreateRoom()
    {
        if (!PhotonNetwork.IsConnected)
            return;

        PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions { MaxPlayers = 8 });

    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom()
    {
        Log("Joined the room");
        PhotonNetwork.LoadLevel("Game");
    }

    private void Log(string message)
    {
        Debug.Log(message);
        LogText.text += "\n";
        LogText.text += message;

    }
}