using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleOfKingdoms.Game.Entities;

namespace BattleOfKingdoms.Game.Cards
{
    public interface ICardResource
    {
        abstract void ApplyResourceCard(Kingdom kingdom);
    }
}
