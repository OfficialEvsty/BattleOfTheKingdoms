using UnityEngine;
public class ButtonPressListener : MonoBehaviour
{
    public event System.Action ButtonPressedEvent;
    public void PressButton()
    {
        ButtonPressedEvent?.Invoke();
    }
}