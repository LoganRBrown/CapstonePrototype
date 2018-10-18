using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState {

    protected PlayerController controller;

    abstract public PlayerState Update();



    virtual public void OnBegin(PlayerController controller, CharacterController charControl)
    {
        this.controller = controller;

    }

    virtual public void OnEnd()
    {

    }

}
