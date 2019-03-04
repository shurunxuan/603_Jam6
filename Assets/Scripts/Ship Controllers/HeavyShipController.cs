using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyShipController : ShipController
{
    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private float thrustStrength;

    // Use this for initialization
    void Start()
    {

    }

    private void FixedUpdate()
    {

        // Thrust
        float thrust = 1;

        if (bDown)
        {
            thrust = 5;
        }

        if (aDown)
        {
            thrust = 5;
        }

        Vector2 moveDirection = axisVector.normalized;
        if (moveDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg + 270;
            rigidbody.MoveRotation(angle);
        }
        
        rigidbody.AddForce(axisVector * thrustStrength * Time.fixedDeltaTime * thrust);

    }
}
