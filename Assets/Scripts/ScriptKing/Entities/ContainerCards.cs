using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun.Demo.SlotRacer.Utils;

public class ContainerCards : MonoBehaviour
{
    [Range(1, 5)]
    [SerializeField] private int i_maxCountCards;
    [SerializeField] private Vector3[] m_cardPositionsInContainerDeck;
    private List<Transform> m_cardsHolder = new List<Transform>();
    //V3

    private void Awake()
    {        
        
    }

    private void FixedUpdate()
    {
                
    }

    public void AddCardInContainer(Transform transformCard)
    {
        if (m_cardsHolder.Count >= i_maxCountCards)
            return;
        transformCard.SetParent(transform);
        m_cardsHolder.Add(transformCard);
        transformCard.position = m_cardPositionsInContainerDeck[m_cardsHolder.Count - 1];
        transformCard.rotation = Quaternion.identity;
    }

    private void RemoveCardsFromContainer()
    {
        foreach(var card in m_cardsHolder)
        {
            card.SetParent(null);
        }
        m_cardsHolder.Clear();
    }

    
}
