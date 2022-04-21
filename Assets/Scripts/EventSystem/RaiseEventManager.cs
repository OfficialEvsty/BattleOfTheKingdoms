using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using ExitGames.Client.Photon;
using BattleOfKingdoms.Game.Entities;

public class RaiseEventManager : MonoBehaviourPun
{
    public const byte NOTIFY_PLAYER_TURN = 0;
    public const byte NOTIFY_PLAYER_TAKES_CARD = 1;
    [SerializeField] private VirtualLeader m_virtualLeader;

    private void OnEnable()
    {
        PhotonNetwork.NetworkingClient.EventReceived += NetworkingClient_EventReceived;        
    }

    private void OnDisable()
    {
        PhotonNetwork.NetworkingClient.EventReceived -= NetworkingClient_EventReceived;
    }

    private void NetworkingClient_EventReceived(EventData obj)
    {
        switch (obj.Code)
        {
            case NOTIFY_PLAYER_TURN:
                bool isTurnEnd = false;

                Debug.Log(obj.CustomData.GetType().IsArray);
                object[] data = (object[])obj.CustomData;
                int viewID = (int)data[0];
                bool hasTurn = (bool)data[1];

                foreach(Player playerQueue in m_virtualLeader.PlayersQueue)
                {
                    Debug.Log($"����� �� ��� (��� ��������):{obj.Sender}*1000 + 1 ViewID: {playerQueue.photonView.ViewID}");
                    //������� �������, ��� ��� �� ����� ��� PhotonView ����������, Player � VirtualLeader � ��� ������ ID �����.
                    if (playerQueue.photonView.ViewID == viewID)
                    {
                        playerQueue.HasTurn = hasTurn;
                        Debug.Log($"�������� HasTurn � ������ {playerQueue.photonView.ViewID} ���� �������� �� {playerQueue.HasTurn}");
                        if (!playerQueue.HasTurn)
                        {
                            isTurnEnd = true;
                            Debug.Log($"Player {playerQueue.photonView.ViewID} �������� ��� � �������� �� ���� ����.");
                        }
                    }                                      
                }
                if (isTurnEnd)
                {
                    m_virtualLeader.OnEndPlayerTurn();
                    isTurnEnd = false;
                }
                break;
            //case NOTIFY_PLAYER_TAKES_CARD:

        }
    }   
}
