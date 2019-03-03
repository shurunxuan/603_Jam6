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

        // Rotate
        //rigidbody.MoveRotation(rigidbody.rotation + axisVector.x * -rotationSpeed * Time.fixedDeltaTime);

        // Thrust
        float thrustScaleY = 0;
        float thrustScaleX = 0;
        float thrust = 1;
        if (InputController.InputData.Type.Joystick == inputType)
        {
            //thrustScaleY = aDown ? 1 : 0;
            thrustScaleY = -axisVectorHeavy.y;
            thrustScaleX = axisVectorHeavy.x;
            

        }
        else if (InputController.InputData.Type.Keyboard == inputType)
        {
            thrustScaleY = axisVector.y;
            thrustScaleX = axisVector.x;
        }

        

        if (bDown)
        {
            Debug.Log("pew pew");
            thrust = 5;
        }

        if (aDown)
        {
            Debug.Log("pew pew");
            thrust = 5;
        }

        //Vector2 moveDirection = rigidbody.velocity;
        //if (moveDirection != Vector2.zero)
        //{
        //    float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        //    rigidbody.MoveRotation(angle);
        //    //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //}




        rigidbody.AddForce(transform.up * thrustScaleY * thrustStrength * Time.fixedDeltaTime * thrust);
        rigidbody.AddForce(transform.right * thrustScaleX * thrustStrength * Time.fixedDeltaTime * thrust);

    }
}
