using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShipController : MonoBehaviour {

    protected new Rigidbody2D rigidbody;
    protected Vector2 axisVector;
    protected bool isFiring = false;

    public GameObject Weapon;
    protected GameObject weaponInstance;
    protected virtual void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();

        weaponInstance = Instantiate(Weapon, transform);
        
        weaponInstance.SetActive(false);
    }

    public void SetAxisVector(Vector2 _axisVector) {
        axisVector = _axisVector;
    }

    public void SetFire(bool _isFiring) {
        isFiring = _isFiring;
    }

}
