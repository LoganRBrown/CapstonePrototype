using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour {

    const float SPEED = 20;

    float deathTimer = 10;

    public static bool isUpgraded = false;

    public static float spellDamage;

    public static string collidedWith;

    public bool invertLookX = false;

    private void Start()
    {
        transform.Rotate(90, 0, 0);
        transform.localScale += new Vector3(.2f, .2f, .2f);
    }



    void Update () {

        transform.position += new Vector3(0, 0, SPEED) * Time.deltaTime;

        deathTimer -= 1 *Time.deltaTime;

        if (isUpgraded)
        {
            transform.Rotate(Vector3.right);
        }

        if(deathTimer <= 0)
        {
            Destroy(gameObject);

            deathTimer = 10;
        }
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        collidedWith = collision.gameObject.name;

        Destroy(gameObject);
    }

    //public void FollowPlayerView()
    //{
    //    float lookX = Input.GetAxis("Mouse X") * (invertLookX ? -1 : 1) * 5;

    //   // transform.Ro(0, lookX, 0);
    //}
}
