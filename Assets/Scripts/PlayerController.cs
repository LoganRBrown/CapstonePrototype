using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour {

    private PlayerState playerState;

    private Camera cam;

    private CharacterController controller;

    public float lookSensitivityX = 5;
    public float lookSensitivityY = 5;
    public bool invertLookX = false;
    public bool invertLookY = true;

    // Use this for initialization
    void Start () {

        SwitchPlayerState(new PlayerStateIdle());

        cam = GetComponentInChildren<Camera>();

        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        LookAround();

        PlayerState newState = playerState.Update();
        SwitchPlayerState(newState);

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
