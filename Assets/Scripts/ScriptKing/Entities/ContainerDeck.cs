using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleOfKingdoms.Game.Inputs;

namespace BattleOfKingdoms.Game.Entities
{
    public class ContainerDeck : MonoBehaviour
    {
        [SerializeField] private ContainerCards m_containerCards;
        [SerializeField] private LinkedList<Transform> m_transformCards = new LinkedList<Transform>();
        private int i_maxCountCards = 5;

        private void Awake()
        {
            OnClickActionsHolder.SwipeEvent += SetCardsInContainer;
        }

        private void Update()
        {

        }

        public void OnContainerCardOnEndPoint(BezierObjEndState state)
        {
            Debug.Log($"State : {state}");
            PullCardsFromContainer(state);
        }

        public void UpdateTransformStack(List<Transform> transformCards)
        {
            m_transformCards.Clear();
            foreach(var card in transformCards)
            {
                m_transformCards.AddLast(card);
            }
            Debug.Log("Update Cards. Cards in Deck: " + m_transformCards.Count);
        }

        private void PullCardsFromContainer(BezierObjEndState state)
        {
            switch (state)
            {
                case BezierObjEndState.Right:
                    for(int i = 0; i < m_containerCards.CurrentCardsCount; i++)
                    {
                        Transform cardReturnToDeck = m_containerCards.RemoveCardFromContainer();
                        m_transformCards.AddLast(cardReturnToDeck);
                        cardReturnToDeck.SetParent(transform);
                        cardReturnToDeck.localPosition = Vector3.zero;
                        cardReturnToDeck.localRotation = Quaternion.Euler(-90, 0, 0);
                        Debug.Log($"Card was inserted in {m_transformCards.Count - 1} position");
                    }                    
                    break;
                case BezierObjEndState.Left:
                    List<Transform> transCards = new List<Transform>();
                    for (int i = 0; i < m_containerCards.CurrentCardsCount; i++)
                    {
                        Transform cardReturnToDeck = m_containerCards.RemoveCardFromContainer();
                        m_transformCards.AddFirst(cardReturnToDeck);
                        cardReturnToDeck.SetParent(transform);
                        cardReturnToDeck.localPosition = Vector3.zero;
                        cardReturnToDeck.rotation = Quaternion.Euler(-135,0,0);
                        Debug.Log($"Card was inserted in first position");
                    }
                    break;
                case BezierObjEndState.None:
                    break;
            }
        }

        private void SetCardsInContainer(Swipe swipe)
        {
            Debug.Log($"Был свайп {swipe}");
            int countCards = 0;
            if (m_transformCards.Count > 0)
                countCards = (m_transformCards.Count > i_maxCountCards) ? i_maxCountCards : m_transformCards.Count;

            Debug.Log("Count of cards: " + countCards);
            switch (swipe)
            {
                case Swipe.Left:
                    for (int i = 0; i < countCards; i++)
                    {
                        Debug.Log($"Левый");
                        m_containerCards.AddCardInContainer(m_transformCards.Last.Value);
                        m_transformCards.RemoveLast();
                    }
                    break;
                case Swipe.Right:
                    for (int i = countCards - 1; i >= 0; i--)
                    {
                        Debug.Log($"Правый");
                        m_containerCards.AddCardInContainer(m_transformCards.First.Value);
                        m_transformCards.RemoveFirst();
                    }
                    break;
                case Swipe.None:
                    break;
            }
        }
    }
}
