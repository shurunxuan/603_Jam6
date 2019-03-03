﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShipController : MonoBehaviour {
    
    protected new Rigidbody2D rigidbody;
    protected Vector2 axisVector;
    protected Vector2 axisVectorHeavy;
    protected bool aDown = false;
    protected bool bDown = false;
    protected InputController.InputData.Type inputType;

    public int HitPoint;
    public GameObject Weapon;
    public Transform[] WeaponSlots;

    protected GameObject[] weaponInstances;
    protected virtual void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();

        weaponInstances = new GameObject[WeaponSlots.Length];
        for (int i = 0; i < WeaponSlots.Length; ++i)
        {
            weaponInstances[i] = Instantiate(Weapon, WeaponSlots[i]);
            weaponInstances[i].transform.localPosition = Vector3.zero;
            weaponInstances[i].transform.localRotation = Quaternion.identity;
            weaponInstances[i].SetActive(false);
        }
    }

    public void SetAxisVector(Vector2 _axisVector) {
        axisVector = _axisVector;
    }

    public void SetAxisVectorHeavy(Vector2 _axisVectorHeavy)
    {
        axisVectorHeavy = _axisVectorHeavy;
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

    void DamageDealed(int damage)
    {
        HitPoint -= damage;
        if (HitPoint <= 0)
        {
            Debug.Log(name + " Died!");
            Destroy(gameObject);
        }
    }

}
