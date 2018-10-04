using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

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

    UniqueAbility[] abilities = new UniqueAbility[3] {
        new UniqueAbility() {type = UniqueAbility.Type.Discount, percentEffect = 100 , attribute = UniqueAbility.Attribute.Mana , duration = 1 },
        new UniqueAbility(),
        new UniqueAbility()
    };

    public Transform cam;

    public float Health = 100;

    public float Mana = 100;

    public float Stamina = 50;

    #region UniqueAbility

    string playerAbility;

    string playerAbilityType;

    float playerAbilityPercent;

    string playerAbilityAttribute;

    float playerAbilityDuration;


    /// <summary>
    /// This is the Unique ability variable that determines the percent to be applied to the specifc attributes determined by the rest of the ability.
    /// </summary>
    float[] abilityPercent = new float[] { 25, 50, 75, 100 };

    /// <summary>
    /// This is the Unique ability variable that determines what typing the ability will have.  
    /// </summary>
    string[] abilityType = new string[] { "Discount", "Invulnerability" };

    /// <summary>
    /// This is the Unique ability variable that determines where to apply the ability.
    /// </summary>
    string[] abilityAttribute = new string[] { "Mana", "Health", "Stamina" };

    /// <summary>
    /// This is the unique ability variable that determines how long the ability lasts for in seconds.
    /// </summary>
    float[] abilityDuration = new float[] { .25f, .5f, .75f, 1 };
#endregion


    Rigidbody body;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody>();
	}

    void Update()
    {
        MoveAround();

        if (Input.GetButtonDown("Jump"))
        {
            body.AddForce(Vector3.up * 5, ForceMode.Impulse);
        }
    }
	
	// Update is called once per frame
	void MoveAround ()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 ballForward = cam.forward;
        ballForward.y = 0;
        ballForward.Normalize();

        Vector3 ballRight = new Vector3(ballForward.z, 0, -ballForward.x);

        Vector3 move = ballForward * v + ballRight * h ;

        Vector3 torque = Vector3.Cross(Vector3.up, move);

        //body.AddForce(move * Time.deltaTime * 1000);
        body.AddTorque(torque * Time.deltaTime * 1000);
	}

    void AssignPlayerAbility()
    {
        int abilPerc = Random.Range(-1, 5);

        int abilType = Random.Range(-1, 2);

        int abilAtt = Random.Range(-1, 3);

        int abilLength = Random.Range(-1, 5);

        playerAbilityPercent = abilityPercent[abilPerc];

        playerAbilityType = abilityType[abilType];

        playerAbilityAttribute = abilityAttribute[abilAtt];

        playerAbilityDuration = abilityDuration[abilLength];

        playerAbility = playerAbilityType + " of " + playerAbilityPercent + "%  to Player " + playerAbilityAttribute + "for " + playerAbilityDuration + " seconds";
    }

    void ActivatePlayerAbility()
    {
        print(playerAbility);

        //switch (playerAbilityAttribute) {
        //    case Health
        //    break;
        //    case
        //    break;
        //    case
        //    break;
        //}
    }
}
