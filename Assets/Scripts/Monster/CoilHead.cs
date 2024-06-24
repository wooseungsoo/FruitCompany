using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class CoilHead : Monster,ISightCheck
{
    // Start is called before the first frame update
    public override void SetAction()
    {
        onChasing+=stateMachine.chasingState.CheckSightChaing;
        //onAttack+=stateMachine.chasingState.AccelerationChasing;

    }
    public void InSight()
    {
        canOperate=false;
    }
    public void OutSight()
    {
        canOperate=true;
    }
}
