using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateIdle : PlayerState {

    override public PlayerState Update()
    {
        //put behavior here

        // put transitions here

        if (Input.GetAxis("Horizontal") == 0 || Input.GetAxis("Vertical") == 0) return new PlayerStateMoving();

        if (Input.GetKeyDown("Fire1") || Input.GetKeyDown("Ability")) return new PlayerStateCombat();

        return null;
    }

}
