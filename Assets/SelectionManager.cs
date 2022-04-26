using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    private Transform m_selected;
    [SerializeField] private int i_numLayerMask = 6;
    [SerializeField] private int i_maxDistance = 10;
    [SerializeField] private LayerMask m_layerMask;
    public Transform SelectedTarget { get { return m_selected; } }


    private void Update()
    {
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, i_maxDistance, m_layerMask))
        {
            Transform objectHit = hit.transform;
            if(objectHit != null)
            {
                m_selected = objectHit;
                Debug.Log($"Ray hits {objectHit.name}");
            }
            
        }
        else
        {
            m_selected = null;
        }
        Debug.DrawRay(ray.origin, ray.direction);
    }

}
