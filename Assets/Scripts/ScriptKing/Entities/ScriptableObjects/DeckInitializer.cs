using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleOfKingdoms.Game.Cards
{

    [CreateAssetMenu(fileName ="new Deck", menuName = "GameAssets/Deck", order = 53)]
    public class DeckInitializer : ScriptableObject
    {
        [SerializeField] private int i_maxEventCards = 128;
        [SerializeField] private int i_maxResiurceCards = 512;

        [SerializeField] private int i_warEventCardsCount = 4;
        [SerializeField] private int i_peaceEventCardsCount = 4;
        [SerializeField] private int i_woodResourceCardsCount = 64;

        public Dictionary<EventCardType, int> EventCardsInDeck = new Dictionary<EventCardType, int>();
        public Dictionary<ResourceCardType, int> ResourceCardsInDeck = new Dictionary<ResourceCardType, int>();

        public DeckInitializer()
        {
            //Event Cards
            EventCardsInDeck[EventCardType.War] = i_warEventCardsCount;
            EventCardsInDeck[EventCardType.Peace] = i_peaceEventCardsCount;
            //Resource Cards
            ResourceCardsInDeck[ResourceCardType.Wood] = i_woodResourceCardsCount;
        }
    }
}
