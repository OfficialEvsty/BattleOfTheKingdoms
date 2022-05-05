using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace BattleOfKingdoms.Game.Inputs
{
    public enum Swipe { Right, Left, None}
    public abstract class GeneralInput : IUpdateDependent
    {
        [System.NonSerialized] public Transform target;
        [System.NonSerialized] public Vector3 targetPoint;
        public Swipe Swipe;
        protected abstract void UpdatePosition();

        protected abstract void UpdateMovement();

        public abstract void OnUpdate();
    }
}
