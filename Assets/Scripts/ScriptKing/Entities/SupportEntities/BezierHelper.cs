using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierHelper : MonoBehaviour
{
    [Header("Точки для построения кривой Безье. Строится всегда по 4 точкам")]
    public Vector3[] m_Points;
    public float lerpModifier;


    [ExecuteAlways]
    private void FixedUpdate()
    {
        transform.position = BezierLine(lerpModifier);
    }

    [ExecuteAlways]
    private Vector3 BezierLine(float lerpMod)
    {
        return Bezier.GetPointPosition(m_Points[0], m_Points[1],
            m_Points[2], m_Points[3], lerpMod);
    }

    public void Reset()
    {
        m_Points = new Vector3[]
        {
            m_Points[0] = new Vector3(1f, 0, 0),
            m_Points[1] = new Vector3(2f, 0, 0),
            m_Points[2] = new Vector3(3f, 0, 0),
            m_Points[3] = new Vector3(4f, 0, 0)
        };
    }

    [ExecuteAlways]
    private void OnDrawGizmos()
    {
        float segments = 20;
        Vector3 previousPoint = BezierLine(0);
        for (int i = 0; i < segments; i++)
        {
            float parameter = i / segments;
            Vector3 point = BezierLine(parameter);
            Gizmos.DrawLine(previousPoint, point);
            previousPoint = point;
        }
    }
}
