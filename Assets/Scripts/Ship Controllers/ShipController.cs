using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShipController : MonoBehaviour {
    
    protected new Rigidbody2D rigidbody;
    protected Vector2 axisVector;
    protected bool aDown = false;
    protected bool bDown = false;
    protected InputController.InputData.Type inputType;

    protected virtual void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void SetAxisVector(Vector2 _axisVector) {
        axisVector = _axisVector;
    }

    public void SetA(bool _aDown) {
        aDown = _aDown;
    }

    public void SetB(bool _bDown) {
        bDown = _bDown;
    }

    public void SetInputType(InputController.InputData.Type _inputType) {
        inputType = _inputType;
    }

}
