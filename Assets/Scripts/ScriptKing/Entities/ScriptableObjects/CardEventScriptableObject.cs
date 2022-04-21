using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleOfKingdoms.Game.Entities;


[CreateAssetMenu(fileName = "new Event Card", menuName = "GameAssets/EventCard", order = 51)]
public class CardEventScriptableObject : ScriptableObject
{
    [SerializeField] private string s_cardName;
    [SerializeField] private string s_description;
    [SerializeField] private int i_value;
    [SerializeField] private Sprite m_sprite;
    [SerializeField] private List<Effect> m_effects;

    public string CardName { get { return s_cardName; } }
    public string Description { get { return s_description; } }
    public int Value { get { return i_value; } }
    public Sprite Sprite { get { return m_sprite; } }
    public List<Effect> Effects { get { return m_effects; } }
}
