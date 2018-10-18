using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {

    public Transform target;
    public float easeMultiplier = 10;

    public float offsetMinY = 1;
    public float offsetMaxY = 5;

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        float percent = .5f;

        Vector3 offset = new Vector3(0, Mathf.Lerp(offsetMinY, offsetMaxY, percent), 0);


        transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.fixedDeltaTime * easeMultiplier);
	}
}
