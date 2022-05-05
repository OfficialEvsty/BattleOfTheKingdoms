using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCards : MonoBehaviour
{
    [Range(1, 5)]
    [SerializeField] private int i_maxCountCards = 5;
    [SerializeField] private Vector3[] m_cardPositionsInContainerDeck;
    private List<Transform> m_cardsHolder = new List<Transform>();

    public int CurrentCardsCount { get { return m_cardsHolder.Count; } }
    //V3

    private void Awake()
    {        
        
    }

    private void FixedUpdate()
    {
                
    }

    public Transform RemoveCardFromContainer()
    {
        Transform transformCard = null;
        if (m_cardsHolder.Count > 0)
        {
            transformCard = m_cardsHolder[0];
            transformCard.SetParent(null);
            transformCard.position = new Vector3(0, 0, 0);
            m_cardsHolder.RemoveAt(0);
        }
        return (transformCard != null) ? transformCard : null;
    }

    public void AddCardInContainer(Transform transformCard)
    {
        if (m_cardsHolder.Count >= i_maxCountCards)
            return;
        transformCard.SetParent(transform);
        m_cardsHolder.Add(transformCard);
        transformCard.localPosition = m_cardPositionsInContainerDeck[m_cardsHolder.Count - 1];
        transformCard.rotation = Quaternion.Euler(new Vector3(transform.parent.rotation.x, 90, 0));
    }

    private void RemoveCardsFromContainer()
    {
        foreach(var card in m_cardsHolder)
        {
            card.SetParent(null);
            card.position = new Vector3(0, 0, 0);
        }
        m_cardsHolder.Clear();
    }

    
}
