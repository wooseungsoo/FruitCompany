using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterIdleState : MonsterBaseState
{
    public MonsterIdleState(MonsterStateMachine monsterStateMachine) : base(monsterStateMachine)
    {

    }

    public override void Enter()
    {
        stateMachine.movementSpeedModifier=0f;//ㅊ
        Debug.Log("Idle 상태 진입");
        //아래에 애니메이션
    }

    public  override void Exit()
    {
        Debug.Log("Idle 상태 나감");

        //애니메이션 스탑
    }

    public override void Update()
    {
        Debug.Log("Idle 상태 중");

        base.Update();

        Debug.Log(IsInChaseRange());
        if(IsInChaseRange())
        {
            stateMachine.ChangeState(stateMachine.chasingState);
            return;
        }
    }


}
