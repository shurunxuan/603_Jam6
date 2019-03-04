using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponReward : Reward {

    public GameObject weaponPrefab;

    public override void ApplyTo(InputController _player) {
        ShipController sc = _player.GetComponentInChildren<ShipController>();
        if (sc != null) {
            sc.Weapon = weaponPrefab;
        }
        Destroy(this.gameObject);
    }

}
