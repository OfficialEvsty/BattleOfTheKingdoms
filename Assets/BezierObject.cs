using Photon.Pun.Demo.SlotRacer.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public enum BezierObjEndState { None, Left, Right} 

public class BezierObject : MonoBehaviour
{
    [Range(0f, 1f)]
    [SerializeField] private float f_position01;
    [SerializeField] private BezierCurve m_bezierCurve;
    [SerializeField] private float f_timeToDelay = 0.01f;
    private float f_calculatedDistance = 0.01f;
    private float f_leftEndPoint = 1f;
    private float f_rightEndPoint = -1f;
    private BezierObjEndState m_endState;

    public UnityEvent<BezierObjEndState> SpecifyBezierObjPositionOnCurveEvent;

    private void Awake()
    {
        OnClickActionsHolder.MoveTrackEvent += CalculatePositionByMouseTrack;
    }

    private void FixedUpdate()
    {
        transform.position = m_bezierCurve.GetPoint(f_position01);
        CheckPositionOnCurve();
    }

    private void CheckPositionOnCurve()
    {
        if(transform.localPosition.x >= f_leftEndPoint)
        {
            Debug.Log("On Left Position");
            m_endState = BezierObjEndState.Left;
        }
        else if(transform.localPosition.x <= f_rightEndPoint)
        {
            Debug.Log("On Right Position");
            m_endState = BezierObjEndState.Right;
        }
        else
        {
            Debug.Log("None");
            m_endState = BezierObjEndState.None;
        }

        if (m_endState != BezierObjEndState.None)
            SpecifyBezierObjPositionOnCurveEvent?.Invoke(m_endState);
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
        f_calculatedDistance = distance / 2000000f;
        StartCoroutine("Delay");
    }
}
