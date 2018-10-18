using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateAttacking : EnemyState {

    public override void OnBegin(EnemyController controller, CharacterController charController)
    {
        base.OnBegin(controller, charController);
    }

    public override EnemyState Update()
    {
        return null;
    }
}
