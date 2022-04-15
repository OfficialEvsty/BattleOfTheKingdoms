using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using BattleOfKingdoms.Game.Input;
public class TurnControls : IUpdateDependent
{

    private ButtonPressListener m_buttonPressListener;
    private float f_pressTimeStamp;
    public bool IsEnabled { get; set; }

    public TurnControls(ButtonPressListener endTurnButton)
    {
        m_buttonPressListener = endTurnButton;
        m_buttonPressListener.ButtonPressedEvent += OnEndTurnButtonPressed;
        IsEnabled = false;
    }

    private void OnEndTurnButtonPressed()
    {
        if (!IsEnabled)
        {
            Debug.Log("Я сломан, не клацай");
            return;
        }
        f_pressTimeStamp = Time.time;
        EndTurnPressed = true;
        
    }

    public void OnInputDestroy()
    {
        m_buttonPressListener.ButtonPressedEvent -= OnEndTurnButtonPressed;
    }

    public void OnUpdate()
    {
        if (EndTurnPressed && Time.time - f_pressTimeStamp > Time.deltaTime)
        {
            EndTurnPressed = false;
        }
    }

    public bool EndTurnPressed { get; private set; }
}