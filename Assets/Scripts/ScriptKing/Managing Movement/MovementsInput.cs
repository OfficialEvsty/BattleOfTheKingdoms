using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BattleOfKingdoms.Game.Input;

public abstract class MovementsInput : IUpdateDependent 
{
    [System.NonSerialized] public Transform target;
    [System.NonSerialized] public Vector3 targetPoint;

    protected abstract void UpdatePosition();

    protected abstract void UpdateMovement();

    public abstract void OnUpdate();
}
