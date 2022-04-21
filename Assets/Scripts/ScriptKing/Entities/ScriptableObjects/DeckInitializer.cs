using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleOfKingdoms.Game.Cards
{

    [CreateAssetMenu(fileName ="new Deck", menuName = "GameAssets/Deck", order = 53)]
    public class DeckInitializer : ScriptableObject
    {
        public List<CardEventScriptableObject> CardsEventDeck;
        public List<CardResourceScriptableObject> CardsResourceDeck;
    }
}
