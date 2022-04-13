using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }
    public RotationAxes m_axes = RotationAxes.MouseXAndY;
    public float SensitivityHor = 9.0f;
    public float SensitivityVert = 9.0f;
    public float MinimumVert = -45.0f;
    public float MaximumVert = 45.0f;
    private float f_rotationX = 0;
    void Start()
    {
        /*Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
            body.freezeRotation = true;*/
    }
    void Update()
    {
        if (m_axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * SensitivityHor, 0);
        }
        else if (m_axes == RotationAxes.MouseY)
        {
            f_rotationX -= Input.GetAxis("Mouse Y") * SensitivityVert;
            f_rotationX = Mathf.Clamp(f_rotationX, MinimumVert, MaximumVert);
            float rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(f_rotationX, rotationY, 0);
        }
        else
        {
            f_rotationX -= Input.GetAxis("Mouse Y") * SensitivityVert;
            f_rotationX = Mathf.Clamp(f_rotationX, MinimumVert, MaximumVert);
            float delta = Input.GetAxis("Mouse X") * SensitivityHor;
            float rotationY = transform.localEulerAngles.y + delta;
            transform.localEulerAngles = new Vector3(f_rotationX, rotationY, 0);
        }
    }
  
}
