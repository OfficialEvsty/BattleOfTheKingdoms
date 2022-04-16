using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleOfKingdoms.Game.Entities;

namespace BattleOfKingdoms.Game.Cards
{
    public interface ICardResource
    {
        CardResourceScriptableObject CardInfo { get; }
        abstract void ApplyResourceCard(Kingdom kingdom);
    }
}
