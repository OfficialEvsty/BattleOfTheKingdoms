using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleOfKingdoms.Networking
{
    public class PlayerHolder : MonoBehaviour
    {
        public Player Player;
        public bool IsReady;

        public void SetPlayerInfo(Player player)
        {
            Player = player;
        }
    }
}