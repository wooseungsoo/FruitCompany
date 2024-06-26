using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scarecrow : Monster
{
   public override void SetAction()
   {
      onChasing+=stateMachine.chasingState.AccelerationChasing;
   }
}
