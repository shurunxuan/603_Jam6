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
        float thrustScale = 0;
        if (InputController.InputData.Type.Joystick == inputType) {
            thrustScale = aDown ? 1 : 0;
        } else if (InputController.InputData.Type.Keyboard == inputType) {
            thrustScale = Mathf.Clamp01(axisVector.y);
        }
        rigidbody.AddForce(transform.up * thrustScale * thrustStrength * Time.fixedDeltaTime);
        
        foreach (var weapon in weaponInstances) {
            foreach (ProjectileSpawner s in weapon.GetComponentsInChildren<ProjectileSpawner>()) {
                s.SetIsShooting(bDown);
            }
        }

    }
}
