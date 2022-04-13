using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EntryPlayerHelper : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private float f_increaseModifier;
    private RectTransform rectButton;
    private RectTransform borderRect;
    private RectTransform m_rectStatus;
    private RectTransform m_rectMaster;
    private Vector2 entryStartSize, borderStartSize, statusStartSize, masterStartSize;
    private Vector2 borderEntryStartAnchor, statusStartAnchor, masterStartAnchor;
    private void Awake()
    {
        rectButton = GetComponent<RectTransform>();
        borderRect = transform.Find("NameBorder").GetComponent<RectTransform>();
        m_rectStatus = transform.Find("Sprite_Status").GetComponent<RectTransform>();
        m_rectMaster = transform.Find("Sprite_Master").GetComponent<RectTransform>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        entryStartSize = rectButton.sizeDelta;

        borderStartSize = borderRect.sizeDelta;
        borderEntryStartAnchor = borderRect.anchoredPosition;

        statusStartSize = m_rectStatus.sizeDelta;
        statusStartAnchor = m_rectStatus.anchoredPosition;

        masterStartSize = m_rectMaster.sizeDelta;
        masterStartAnchor = m_rectMaster.anchoredPosition;

        HighlightButton(f_increaseModifier);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OffHighlightButton();
    }

    private void HighlightButton(float modifier)
    {
        rectButton.sizeDelta = new Vector2(rectButton.sizeDelta.x * modifier, rectButton.sizeDelta.y * modifier);
        borderRect.sizeDelta = new Vector2(borderRect.sizeDelta.x * modifier, borderRect.sizeDelta.y * modifier);
        borderRect.anchoredPosition = new Vector2(borderRect.anchoredPosition.x * modifier, borderRect.anchoredPosition.y);
        m_rectStatus.sizeDelta = new Vector2(m_rectStatus.sizeDelta.x * modifier, m_rectStatus.sizeDelta.y * modifier);
        m_rectStatus.anchoredPosition = new Vector2(m_rectStatus.anchoredPosition.x * modifier, m_rectStatus.anchoredPosition.y);
        m_rectMaster.sizeDelta = new Vector2(m_rectMaster.sizeDelta.x * modifier, m_rectMaster.sizeDelta.y * modifier);
        m_rectMaster.anchoredPosition = new Vector2(m_rectMaster.anchoredPosition.x * modifier, m_rectMaster.anchoredPosition.y);
    }

    private void OffHighlightButton()
    {
        rectButton.sizeDelta = entryStartSize;
        borderRect.sizeDelta = borderStartSize;
        borderRect.anchoredPosition = borderEntryStartAnchor;
        m_rectStatus.sizeDelta = statusStartSize;
        m_rectStatus.anchoredPosition = statusStartAnchor;
        m_rectMaster.sizeDelta = masterStartSize;
        m_rectMaster.anchoredPosition = masterStartAnchor;
    }
}
