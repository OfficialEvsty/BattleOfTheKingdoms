using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using ExitGames.Client.Photon;
using BattleOfKingdoms.Game.Entities;

public class RaiseEventManager : MonoBehaviourPun
{
    public const byte NOTIFY_PLAYER_TURN = 0;
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
        Debug.Log($"Очередь из {m_virtualLeader.PlayersQueue.Count}");
        switch (obj.Code)
        {
            case NOTIFY_PLAYER_TURN:
                bool isTurnEnd = false;
                foreach(Player playerQueue in m_virtualLeader.PlayersQueue)
                {
                    Debug.Log($"Вызов то был (Кто отправил):{obj.Sender}*1000 + 1 ViewID: {playerQueue.photonView.ViewID}");
                    //Жесткий костыль, так как на сцене два PhotonView компонента, Player и VirtualLeader и они разные ID имеют.
                    if (playerQueue.photonView.ViewID == obj.Sender * 1000 + 1)
                    {
                        playerQueue.HasTurn = (bool)obj.CustomData;
                        Debug.Log($"Свойство HasTurn у игрока {playerQueue.photonView.ViewID} было изменено на {playerQueue.HasTurn}");
                        if (!playerQueue.HasTurn)
                        {
                            isTurnEnd = !playerQueue.HasTurn;
                            Debug.Log($"Player {playerQueue.photonView.ViewID} закончил ход и уведомил об этом всех.");
                        }
                    }                                      
                }
                if (isTurnEnd)
                {
                    m_virtualLeader.OnEndPlayerTurn();
                    isTurnEnd = false;
                }
                break;  
        }
    }   
}
