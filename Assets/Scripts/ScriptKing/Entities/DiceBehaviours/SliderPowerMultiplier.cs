using UnityEngine;
using UnityEngine.UI;

public class SliderPowerMultiplier : MonoBehaviour
{
    [System.NonSerialized] public Slider m_slider;

    private void Start()
    {
        m_slider = GetComponent<Slider>();
    }

}
