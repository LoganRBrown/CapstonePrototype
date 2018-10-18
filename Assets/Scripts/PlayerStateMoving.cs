using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMoving : PlayerState {

    public float speed = 5;

    CharacterController pawn;


    public override void OnBegin(PlayerController controller, CharacterController charControl)
    {
        base.OnBegin(controller, charControl);

        pawn = charControl;
    }

    override public PlayerState Update()
    {
        //put behavior here

        MoveAround();

        // put transitions here

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) return new PlayerStateIdle();

        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            return new PlayerStateCombat();
        }

        return null;
    }

    private void MoveAround()
    {

        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        Vector3 velocity = Vector3.zero;
        velocity += controller.transform.forward * v * speed;
        velocity += controller.transform.right * h * speed;

        pawn.SimpleMove(velocity);
    }

}
