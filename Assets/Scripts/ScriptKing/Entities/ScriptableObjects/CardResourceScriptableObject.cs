using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Resource Card", menuName = "ResourceCard", order = 52)]
public class CardResourceScriptableObject : ScriptableObject
{
    [SerializeField] private CardType m_cardType;
    [SerializeField] private string s_cardName;
    [SerializeField] private string s_description;
    [SerializeField] private int i_value;
    [SerializeField] private int i_count;
    [SerializeField] private Sprite m_sprite;

    public CardType CardType { get { return m_cardType; } }
    public string CardName { get { return s_cardName; } }
    public string Description { get { return s_description; } }
    public int Value { get { return i_value; } }
    public int Count { get { return i_count; } }
    public Sprite Sprite { get { return m_sprite; } }
}
