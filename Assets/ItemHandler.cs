using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    private Transform m_itemInHandle;
    [SerializeField] private float f_distanceToPickUp = 5;


    private void Awake()
    {
        OnClickActionsHolder.PickUpClickEvent += OnPlayerPressedPickUp;
        OnClickActionsHolder.ThrowOutClickEvent += OnPlayerPressedThrowOut;
    }

    private void OnDestroy()
    {
        OnClickActionsHolder.PickUpClickEvent -= OnPlayerPressedPickUp;
        OnClickActionsHolder.ThrowOutClickEvent -= OnPlayerPressedThrowOut;
    }

    private void OnPlayerPressedPickUp(Transform transformToPickUp)
    {
        var distance = Vector3.Distance(transform.position, transformToPickUp.position);
        if(distance <= f_distanceToPickUp)
        {
            PickUp(transformToPickUp);
        }
    }

    private void OnPlayerPressedThrowOut()
    {
        ThrowOut();
    }

    private void PickUp(Transform transformToPickUp)
    {
        transformToPickUp.SetParent(transform);
        transformToPickUp.transform.position = transform.position;
        transformToPickUp.rotation = transform.rotation;
        transformToPickUp.GetComponent<Rigidbody>().isKinematic = true;
        m_itemInHandle = transformToPickUp;
    }

    private void ThrowOut()
    {
        if (m_itemInHandle)
        {
            m_itemInHandle.parent = null;
            m_itemInHandle.GetComponent<Rigidbody>().isKinematic = false;
            m_itemInHandle = null;
        }
    }
}
