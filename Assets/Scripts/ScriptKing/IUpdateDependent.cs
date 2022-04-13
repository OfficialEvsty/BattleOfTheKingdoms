using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleOfKingdoms.Game.Input
{
    public interface IUpdateDependent
    {
        abstract void OnUpdate();
    }
}

