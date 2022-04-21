using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleOfKingdoms.Game.Entities;

[CreateAssetMenu(fileName = "new Resource Card", menuName = "GameAssets/ResourceCard", order = 52)]
public class CardResourceScriptableObject : ScriptableObject
{
    [SerializeField] private ResourceType m_resourceType;
    [SerializeField] private string s_cardName;
    [SerializeField] private string s_description;
    [SerializeField] private int i_value;
    [SerializeField] private int i_count;
    [SerializeField] private Sprite m_sprite;

    public ResourceType CardType { get { return m_resourceType; } }
    public string CardName { get { return s_cardName; } }
    public string Description { get { return s_description; } }
    public int Value { get { return i_value; } }
    public int Count { get { return i_count; } }
    public Sprite Sprite { get { return m_sprite; } }
}
