using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour {

    const float SPEED = 20;

    float deathTimer = 10;

    public static bool isUpgraded = false;

    public static float spellDamage;

    public static string collidedWith;

	
	// Update is called once per frame
	void Update () {

        transform.position += new Vector3(0, 0, SPEED) * Time.deltaTime;

        deathTimer -= 1 *Time.deltaTime;

        if (isUpgraded)
        {
            transform.Rotate(Vector3.right);
        }

        if(deathTimer <= 0)
        {
            Destroy(this);

            deathTimer = 10;
        }
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        collidedWith = collision.gameObject.name;

        Destroy(this);
    }
}
