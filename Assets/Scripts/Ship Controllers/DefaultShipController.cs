using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultShipController : ShipController {

    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private float thrustStrength;

    // Use this for initialization
    void Start () {
		
	}

    private void FixedUpdate() {

        // Rotate
        rigidbody.MoveRotation(rigidbody.rotation + axisVector.x * -rotationSpeed * Time.fixedDeltaTime);

        // Thrust
        rigidbody.AddForce(transform.up * axisVector.y * thrustStrength * Time.fixedDeltaTime);

        if (isFiring) {
            Debug.Log("pew pew");
        }

    }
}
