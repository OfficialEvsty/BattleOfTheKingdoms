using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using ExitGames.Client.Photon;

namespace BattleOfKingdoms.Game.Entities
{

    public class CustomDataType : MonoBehaviourPunCallbacks
    {

        private void Awake()
        {
            //bool isPlayerRegistered = PhotonPeer.RegisterType(typeof(Player), (byte)'P', Player.Serialize, Player.Deserialize);
            //Debug.Log($"Is Type(Player) registered: {isPlayerRegistered}.");
        }
    }
}
