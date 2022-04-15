using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BattleOfKingdoms.Game.Input;
using Photon.Pun;
public class PlayerInput : MonoBehaviourPunCallbacks
{
    private ButtonPressListener m_buttonPressListener;
    private List<IUpdateDependent> m_updateDependents = new List<IUpdateDependent>();
    public TurnControls TurnControls { get; private set; }
    public MovementInput MovementInput { get; private set; }    

    private void Awake()
    {        
        m_buttonPressListener = FindObjectOfType<ButtonPressListener>();
        TurnControls = new TurnControls(m_buttonPressListener);
        MovementInput = new MovementKeyBoard(transform);
        m_updateDependents.AddRange(new List<IUpdateDependent> { TurnControls, MovementInput});
    }

    private void Update()
    {
        if (photonView.IsMine)
        {
            foreach (var updateDependent in m_updateDependents)
            {
                updateDependent.OnUpdate();
            }
        }        
    }

    private void OnDestroy()
    {
        Debug.Log("Событие на кнопки уничтожилось");
        TurnControls.OnInputDestroy();
    }
}
