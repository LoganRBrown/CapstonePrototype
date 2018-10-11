using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class EnemyController : MonoBehaviour {

    private EnemyState enemyState;

    private CharacterController controller;

    private GameObject player;

    private EnemyStateIdle idle = new EnemyStateIdle();

    public bool isBoss = false;

    public float degreesToRotate = 180;

    public LayerMask rayMask;

    Vector3 previous = Vector3.zero;

    float timer = 5;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");

        SwitchEnemyState(new EnemyStateIdle());

        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {

        //Debug.Log(idle);

        if(enemyState != null)
        {
            Patrol();
        }

        PlayerInSight(player, this);

        EnemyState newState = enemyState.Update();
        SwitchEnemyState(newState);
		
	}

    private void SwitchEnemyState(EnemyState newState)
    {
        if (newState != null)
        {
            if (enemyState != null) enemyState.OnEnd();
            enemyState = newState;
            enemyState.OnBegin(this, controller);
        }
    }

    private void Patrol()
    {
        Vector3 velocity = Vector3.zero;
        velocity += controller.transform.forward * 3;
        controller.SimpleMove(velocity);
        Vector3 current = controller.transform.position;

        timer -= 1 *Time.deltaTime;

        if(timer <= 0)
        {

            if (current == previous)
            {
                controller.transform.Rotate(Vector3.up, degreesToRotate);
            }

            timer = 5;
        }


        previous = controller.transform.position;


    }

    public bool PlayerInSight(GameObject player, EnemyController enemy)
    {


        //Direction (Dot product of e's direction and (p * e) normalized i.e. return between -1 & 1

        Vector3 forward = enemy.transform.forward;
        Vector3 toPlayer = player.transform.position - enemy.transform.position;

        //Distance (p * e) mag
        float distance = toPlayer.magnitude;

        float direction = Vector3.Dot(forward, toPlayer.normalized);

        //occulision (raycast from e to p)

        Debug.Log(distance);

        if(distance <= 15)
        {
            if(direction >= .5f)
            {
                RaycastHit hit;
                if (Physics.Raycast(enemy.transform.position, toPlayer, out hit, Mathf.Infinity, rayMask))
                {
                    Debug.Log("Did Hit");
                    //can see player
                    return true;
                }
                else
                {
                    Debug.Log("Did not Hit");
                    //cannot see player

                }
            }
        }



        return false;
    }
}
