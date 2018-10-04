using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateCombat : PlayerState {

    public override void OnBegin(PlayerController controller, CharacterController charControl)
    {
        base.OnBegin(controller, charControl);

        Debug.Log("In Combat");
    }

    override public PlayerState Update()
    {
        //put behavior here
        Debug.Log("In Combat");

        // put transitions here

        return null;
    }
}
