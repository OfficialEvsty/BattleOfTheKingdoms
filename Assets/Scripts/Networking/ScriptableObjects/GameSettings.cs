using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Manager/GameSettings")]
public class GameSettings : ScriptableObject
{
    [SerializeField]
    private string s_gameVersion = "0.0.0";
    public string GameVersion { get { return s_gameVersion; } }

    [SerializeField]
    private string s_nickName = "Player";
    public string NickName
    {
        get
        {
            int value = Random.Range(1000, 9999);
            return s_nickName + value.ToString();
        }
    }
}
