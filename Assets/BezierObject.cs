using Photon.Pun.Demo.SlotRacer.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierObject : MonoBehaviour
{
    [Range(0f, 1f)]
    [SerializeField] private float f_position01;
    [SerializeField] private BezierCurve m_bezierCurve;
    [SerializeField] private float f_timeToDelay = 0.01f;
    private float f_calculatedDistance = 0.01f;

    private void Awake()
    {
        OnClickActionsHolder.MoveTrackEvent += CalculatePositionByMouseTrack;
    }

    private void FixedUpdate()
    {
        transform.position = m_bezierCurve.GetPoint(f_position01);
    }

    private IEnumerator Delay()
    {
        for (int i = 0; i < 100; i++)
        {
            if (f_position01 > 1 && f_calculatedDistance > 0)
                break;
            if (f_position01 < 0 && f_calculatedDistance < 0)
                break;
            f_position01 += f_calculatedDistance;
            yield return new WaitForSeconds(f_timeToDelay);
            m_bezierCurve.GetPoint(f_position01);

        }
    }

    private void CalculatePositionByMouseTrack(float distance)
    {
        Debug.Log($"Пришел {distance}") ;
        f_calculatedDistance = distance / 200000f;
        StartCoroutine("Delay");
    }
}
