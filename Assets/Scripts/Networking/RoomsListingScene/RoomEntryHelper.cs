using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RoomEntryHelper : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private float f_increaseModifier;
    private RectTransform m_rectRoomPf;
    private RectTransform m_borderNameRect;
    private RectTransform m_borderCountRect;
    private Vector2 entryStartSize, nameStartSize, nameStartAnchor, countStartSize, countStartAnchor;

    private void Awake()
    {
        m_rectRoomPf = GetComponent<RectTransform>();
        m_borderNameRect = transform.Find("NameSpaceSprite").GetComponent<RectTransform>();
        m_borderCountRect = transform.Find("PlayerCountSprite").GetComponent<RectTransform>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        entryStartSize = m_rectRoomPf.sizeDelta;
        nameStartSize = m_borderNameRect.sizeDelta;
        nameStartAnchor = m_borderNameRect.anchoredPosition;
        countStartSize = m_borderCountRect.sizeDelta;
        countStartAnchor = m_borderCountRect.anchoredPosition;

        HighlightButton(f_increaseModifier);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OffHighlightButton();
    }

    private void HighlightButton(float modifier)
    {
        m_rectRoomPf.sizeDelta = new Vector2(m_rectRoomPf.sizeDelta.x * modifier, m_rectRoomPf.sizeDelta.y * modifier);
        m_borderNameRect.sizeDelta = new Vector2(m_borderNameRect.sizeDelta.x * modifier, m_borderNameRect.sizeDelta.y * modifier);
        m_borderNameRect.anchoredPosition = new Vector2(m_borderNameRect.anchoredPosition.x * modifier, m_borderNameRect.anchoredPosition.y);
        m_borderCountRect.sizeDelta = new Vector2(m_borderCountRect.sizeDelta.x * modifier, m_borderCountRect.sizeDelta.y * modifier);
        m_borderCountRect.anchoredPosition = new Vector2(m_borderCountRect.anchoredPosition.x * modifier, m_borderCountRect.anchoredPosition.y);
    }

    private void OffHighlightButton()
    {
        m_rectRoomPf.sizeDelta = entryStartSize;
        m_borderNameRect.sizeDelta = nameStartSize;
        m_borderNameRect.anchoredPosition = nameStartAnchor;
        m_borderCountRect.sizeDelta = countStartSize;
        m_borderCountRect.anchoredPosition = countStartAnchor;
    }
}
