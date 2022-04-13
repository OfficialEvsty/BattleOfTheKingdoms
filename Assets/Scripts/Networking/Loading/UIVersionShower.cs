using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

namespace BattleOfKingdoms.Networking
{
    public class UIVersionShower : MonoBehaviour
    {
        [SerializeField] private TMP_Text m_textVersion;
        private void Start()
        {
            m_textVersion.text = "Version: " + MasterManager.GameSettings.GameVersion;
        }
    }
}
