using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipReward : Reward {

    public override void ApplyTo(InputController _player) {
        Debug.Log("Ship reward applied to Player" + _player.playerNum);
        Destroy(this.gameObject);
    }

}
