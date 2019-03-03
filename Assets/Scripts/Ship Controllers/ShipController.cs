using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShipController : MonoBehaviour {

    protected new Rigidbody2D rigidbody;
    protected Vector2 axisVector;
    protected bool isFiring = false;

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

    public void SetFire(bool _isFiring) {
        isFiring = _isFiring;
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
