using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateCombat : PlayerState {

    private GameObject[] enemies;

    public static float spellCost = 10;

    CharacterController pawn;

    float speed = 5;

    public override void OnBegin(PlayerController controller, CharacterController charControl)
    {
        base.OnBegin(controller, charControl);

        pawn = charControl;

        FetchEnemies();

    }

    override public PlayerState Update()
    {
        //put behavior here

        MoveAround();

        foreach (GameObject enemy in enemies)
        {

        }

        // put transitions here

        return null;
    }

    public void FetchEnemies()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    private void CastSpell()
    {

    }

    private void HandleCombat()
    {

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
