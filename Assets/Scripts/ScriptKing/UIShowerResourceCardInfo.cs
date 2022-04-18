using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIShowerResourceCardInfo : MonoBehaviour
{
    [SerializeField] private CardResourceScriptableObject m_cardResourceSO;
    public CardResourceScriptableObject CardInfo { get { return m_cardResourceSO; } }

    [SerializeField] private TMP_Text m_cardName;
    [SerializeField] private TMP_Text m_description;
    [SerializeField] private TMP_Text m_value;
    [SerializeField] private TMP_Text m_count;
    [SerializeField] private Sprite m_sprite;

    private void Awake()
    {
        m_cardName.text = CardInfo.CardName;
        m_description.text = CardInfo.Description;
        m_value.text = CardInfo.Value.ToString();
        m_count.text = CardInfo.Count.ToString();
        //m_sprite = m_cardEventSO.Sprite;
    }
}
