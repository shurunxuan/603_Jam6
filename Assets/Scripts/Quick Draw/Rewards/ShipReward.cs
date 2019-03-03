using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipReward : Reward {

    public GameObject shipPrefab;

    public override void ApplyTo(InputController _player) {
        _player.SetShip(shipPrefab);
        Destroy(this.gameObject);
    }

}
