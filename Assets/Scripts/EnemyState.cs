using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState {

    protected EnemyController controller;

    abstract public EnemyState Update();
	
	virtual public void OnBegin(EnemyController controller, CharacterController charController)
    {
        this.controller = controller;
    }

    virtual public void OnEnd()
    {

    }
	
}
