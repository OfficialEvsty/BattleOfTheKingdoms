using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementKeyBoard : MovementsInput
{
    [SerializeField] public float f_movementSpeed = 2;
    private Transform m_targetTransform;
    private MouseLook m_mouseLook;
    public MovementKeyBoard(Transform targetTransform)
    {
        m_targetTransform = targetTransform;
        m_mouseLook = new MouseLook(targetTransform);
    }
    protected override void UpdateMovement()
    {
        throw new System.NotImplementedException();
    }

    public override void OnUpdate()
    {
        UpdatePosition();
        m_mouseLook.UpdateRotation();
    }

    protected override void UpdatePosition()
    {
        float verticalMove = Input.GetAxis("Vertical");
        float horizontalMove = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(horizontalMove, 0, verticalMove);
        m_targetTransform.Translate(movement * f_movementSpeed * Time.fixedDeltaTime);
    }
}
