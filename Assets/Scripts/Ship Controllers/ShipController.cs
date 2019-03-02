using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShipController : MonoBehaviour {

    protected new Rigidbody2D rigidbody;
    protected Vector2 axisVector;
    protected bool isFiring = false;

    protected virtual void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void SetAxisVector(Vector2 _axisVector) {
        axisVector = _axisVector;
    }

    public void SetFire(bool _isFiring) {
        isFiring = _isFiring;
    }

}
