using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementKeyBoard : MovementInput
{
    [SerializeField] public float f_movementSpeed = 5;
    private Transform m_targetTransform;
    public MovementKeyBoard(Transform targetTransform)
    {
        m_targetTransform = targetTransform;
    }
    protected override void UpdateMovement()
    {
        throw new System.NotImplementedException();
    }

    public void LateUpdate()
    {
        UpdatePosition(); 
    }

    protected override void UpdatePosition()
    {
        Debug.Log("Call");
        float verticalMove = Input.GetAxis("Vertical");
        float horizontalMove = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(verticalMove, 0, horizontalMove);
        m_targetTransform.Translate(movement * f_movementSpeed * Time.fixedDeltaTime);
    }
}
