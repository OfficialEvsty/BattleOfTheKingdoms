using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleOfKingdoms.Game.Inputs;

public class OnClickActionsHolder
{
    public static System.Action EscapeClickEvent;
    public static System.Action<Transform> PickUpClickEvent;
    public static System.Action ThrowOutClickEvent;
    public static System.Action<float> MoveTrackEvent;
    public static System.Action<Swipe> SwipeEvent;
}
