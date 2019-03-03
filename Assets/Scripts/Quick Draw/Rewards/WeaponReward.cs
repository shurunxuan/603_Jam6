using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponReward : Reward {

    public override void ApplyTo(InputController _player) {
        Debug.Log("Weapon reward applied to Player" + _player.playerNum);
        Destroy(this.gameObject);
    }

}
