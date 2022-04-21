using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleOfKingdoms.Game.Inputs
{
    public interface IUpdateDependent
    {
        abstract void OnUpdate();
    }
}

