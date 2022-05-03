using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Bezier
{    
    public static Vector3 GetPointPosition(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4, float t)
    {
        t = Mathf.Clamp01(t);
        float oneMinusT = (1 - t);
        return
            oneMinusT * oneMinusT * oneMinusT * p1 +
            oneMinusT * oneMinusT * t * p2 +
            oneMinusT * t * t * p3 +
            t * t * t * p4;
    }
}
