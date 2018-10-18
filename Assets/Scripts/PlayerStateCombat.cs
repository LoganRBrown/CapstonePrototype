using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateCombat : PlayerState {

    private GameObject[] enemies;

    public static float spellCost;

    public Spell prefabSpell;

    List<Spell> spells = new List<Spell>();

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

        CastSpell();

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
        Vector3 pos = pawn.transform.position;
        pos += new Vector3(0, 0, 2);

        if (Input.GetMouseButtonDown(0))
        {
            spellCost = 10;
            Spell newSpell = GameObject.Instantiate(prefabSpell, pos, Quaternion.identity);
            Spell.isUpgraded = false;
            spells.Add(newSpell);
            PlayerController.playerMana -= spellCost;
        }

        if (Input.GetMouseButtonDown(1))
        {
            spellCost = 50;
            Spell newSpell = GameObject.Instantiate(prefabSpell, pos, Quaternion.identity);
            Spell.isUpgraded = true;
            spells.Add(newSpell);
            PlayerController.playerMana -= spellCost;
        }
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
