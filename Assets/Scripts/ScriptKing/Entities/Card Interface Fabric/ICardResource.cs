using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleOfKingdoms.Game.Entities;

namespace BattleOfKingdoms.Game.Cards
{
    public interface ICardResource
    {
        ResourceCardType ResourceCardType { get; }
        abstract void ApplyResourceCard(Kingdom kingdom);
    }
}
