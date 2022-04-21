using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleOfKingdoms.Game.Entities;

namespace BattleOfKingdoms.Game.Cards
{
    public interface ICardEvent
    {
        abstract void ApplyEventCard(Kingdom kingdom);
    }
}

