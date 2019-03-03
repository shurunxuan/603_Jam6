using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponReward : Reward {

    public GameObject weaponPrefab;

    public override void ApplyTo(InputController _player) {
        _player.GetComponentInChildren<ShipController>().Weapon = weaponPrefab;
        Destroy(this.gameObject);
    }

}
