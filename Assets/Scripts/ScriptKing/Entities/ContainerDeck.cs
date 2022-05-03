using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleOfKingdoms.Game.Cards;

namespace BattleOfKingdoms.Game.Entities
{
    public class ContainerDeck : MonoBehaviour
    {
        [SerializeField] private ContainerCards m_containerCards;
        private List<Transform> m_transformCards = new List<Transform>();

        private void Update()
        {

        }

        public void UpdateTransformStack(List<Transform> transformCards)
        {
            m_transformCards.Clear();
            foreach(var card in transformCards)
            {
                m_transformCards.Add(card);
            }
            Debug.Log("Update Cards. Cards in Deck: " + m_transformCards.Count);
        }

        private void SetCardsInContainer(bool isAbove, int countCards)
        {
            bool isCountValid = countCards <= 5 && countCards > 0;
            if (isCountValid)
                return;
            if (m_transformCards.Count < countCards)
                return;

            if (isAbove)
            {
                for (int i = 0; i < countCards; i++)
                {
                    m_containerCards.AddCardInContainer(m_transformCards[i]);
                    m_transformCards.RemoveAt(i);
                }
            }
            else
            {
                for (int i = countCards - 1; i >= 0; i--)
                {
                    m_containerCards.AddCardInContainer(m_transformCards[i]);
                    m_transformCards.RemoveAt(i);
                }
            }
        }
    }
}
