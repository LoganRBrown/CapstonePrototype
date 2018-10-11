using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateIdle : EnemyState {

    //CharacterController pawn;

    public override void OnBegin(EnemyController controller, CharacterController charController)
    {
        base.OnBegin(controller, charController);

        //pawn = charController;
    }

    public override EnemyState Update()
    {

        return null;

    }



    

    
}
