using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class SceneUIController : MonoBehaviourPunCallbacks
{
    private bool b_isUIPanelActive = false;
    [SerializeField] private GameObject m_panel;

    private void Awake()
    {
        OnClickActionsHolder.EscapeClickEvent += ChangeStatePanel;
    }

    private void OnDestroy()
    {
        OnClickActionsHolder.EscapeClickEvent -= ChangeStatePanel;
    }

    public void ChangeStatePanel()
    {
        b_isUIPanelActive = !b_isUIPanelActive;
        m_panel.SetActive(b_isUIPanelActive);
    }
    public void OnExitButtonClicked()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        SceneManager.LoadScene("Menu");
    }
}
