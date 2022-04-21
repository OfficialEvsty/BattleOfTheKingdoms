using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIShowerResourceCardInfo : MonoBehaviour
{    
    [SerializeField] private TMP_Text m_cardName;
    [SerializeField] private TMP_Text m_description;
    [SerializeField] private TMP_Text m_value;
    [SerializeField] private TMP_Text m_count;
    [SerializeField] private Sprite m_sprite;

    public void SetInfo(CardResourceScriptableObject cardEventSO)
    {
        m_cardName.text = cardEventSO.CardName;
        m_description.text = cardEventSO.Description;
        m_value.text = cardEventSO.Value.ToString();
        m_count.text = cardEventSO.Count.ToString();
        //m_sprite = m_cardEventSO.Sprite;
    }
}
