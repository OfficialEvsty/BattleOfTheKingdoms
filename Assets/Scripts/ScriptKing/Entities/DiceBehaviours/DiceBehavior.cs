using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceBehavior : MonoBehaviour
{
    public LogicOfDice m_logicOfDiceBehavior = new LogicOfDice();
    private static Rigidbody m_rigidbody;
    private float f_powerMultiplier;
    public static Vector3 m_diceVelocity;
    private List<SideOfTheDice> SideOfTheDice = new List<SideOfTheDice>();
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();

        foreach (SideOfTheDice item in FindObjectsOfType(typeof(SideOfTheDice)))
        {
            SideOfTheDice.Add(item);
        }

    }

    // Update is called once per frame
    void Update()
    {
        m_diceVelocity = m_rigidbody.velocity;
        f_powerMultiplier = FindObjectOfType<SliderPowerMultiplier>().m_slider.value;

        if (m_diceVelocity.x == 0f &&
            m_diceVelocity.y == 0f &&
            m_diceVelocity.z == 0f)
        {
            //m_logicOfDiceBehavior.GetResult(SideOfTheDice, DiceBehavior.m_diceVelocity);
            Debug.Log("Результат броска: " + m_logicOfDiceBehavior.GetResult(SideOfTheDice, DiceBehavior.m_diceVelocity));
        }
    }

    //Quaternion quaternion;

    public void ButtonTrhow()
    {
        if (transform.parent == null) 
            return;
        //quaternion = transform.localRotation;
        m_rigidbody.isKinematic = false;
        transform.parent = null;
        ////Костыль!!
        //FindObjectOfType<CapturingDice>().gameObject.SetActive(false);
        m_logicOfDiceBehavior.Trhow(transform, m_rigidbody, f_powerMultiplier/*, quaternion*/);
    }

    private void OnMouseDown()
    {
        transform.SetParent(FindObjectOfType<ItemHandler>().gameObject.transform, true);
        transform.localPosition = new Vector3(0f, 0f, 0f);
        transform.localRotation = Quaternion.identity;
        m_rigidbody.isKinematic = true;
    }
}
