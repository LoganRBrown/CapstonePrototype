using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour {

    public struct UniqueAbility
    {
        public enum Type
        {
            Discount,
            Invulnerability
        }
        public enum Attribute
        {
            Health,
            Mana,
            Stamina
        }

        public Type type;
        public float percentEffect;
        public Attribute attribute;
        public float duration;
    }

    UniqueAbility[] abilities = new UniqueAbility[2] {
        new UniqueAbility() {type = UniqueAbility.Type.Discount, percentEffect = 100 , attribute = UniqueAbility.Attribute.Mana , duration = 1 },
        new UniqueAbility() {type = UniqueAbility.Type.Invulnerability, percentEffect = 100, attribute = UniqueAbility.Attribute.Health, duration = .5f }
    };

    private PlayerState playerState;

    public UniqueAbility playerClass;

    private Camera cam;

    private CharacterController controller;

    public Spell prefabSpellToAccess;

    public float playerHealth = 100;

    public static float playerMana = 100;

    public float lookSensitivityX = 5;
    public float lookSensitivityY = 5;
    public bool invertLookX = false;
    public bool invertLookY = true;



    void Start () {

        playerClass = abilities[0];

        SwitchPlayerState(new PlayerStateIdle());

        cam = GetComponentInChildren<Camera>();

        controller = GetComponent<CharacterController>();


	}
	
	void Update ()
    {
        LookAround();

        PlayerState newState = playerState.Update();
        SwitchPlayerState(newState);

        if (Input.GetButtonDown("Ability")) UseAbility();

    }

    private void UseAbility()
    {
        float abilityTimer = playerClass.duration * Time.deltaTime;

        float oldSpellCost = PlayerStateCombat.spellCost;

        while(abilityTimer > 0)
        {

            if (playerClass.type == UniqueAbility.Type.Discount)
            {
                if(playerClass.attribute == UniqueAbility.Attribute.Mana)
                {
                    float newSpellCost = (oldSpellCost / playerClass.percentEffect) * 100;

                    PlayerStateCombat.spellCost = newSpellCost;
                }
            }

            abilityTimer -= Time.deltaTime;

        }

        if(abilityTimer <= 0)
        {
            PlayerStateCombat.spellCost = oldSpellCost;
        }

    }

    private void SwitchPlayerState(PlayerState newState)
    {
        if (newState != null)
        {
            if(playerState != null) playerState.OnEnd();
            playerState = newState;
            playerState.OnBegin(this, controller);
        }
    }

    public void LookAround()
    {
        float lookX = Input.GetAxis("Mouse X") * (invertLookX ? -1 : 1) * lookSensitivityX;
        float lookY = Input.GetAxis("Mouse Y") * (invertLookY ? -1 : 1) * lookSensitivityY;

        transform.Rotate(0, lookX, 0);

        float newAngle = cam.transform.localEulerAngles.x + lookY;

        if (newAngle > 80 && newAngle < 280) return;
        cam.transform.Rotate(lookY, 0, 0);

    }

}
