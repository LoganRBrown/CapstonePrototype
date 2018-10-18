using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateIdle : PlayerState {

    override public PlayerState Update()
    {

        if (Input.GetAxis("Horizontal") == 0 || Input.GetAxis("Vertical") == 0) return new PlayerStateMoving();

        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            return new PlayerStateCombat();
        }

        return null;
    }

}
