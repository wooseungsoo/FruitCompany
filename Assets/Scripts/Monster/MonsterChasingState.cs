using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterChasingState : MonsterBaseState
{
    public MonsterChasingState(MonsterStateMachine monsterStateMachine) : base(monsterStateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log("chasing 상태 진입");

        stateMachine.movementSpeedModifier=1;

        //애니메이션 시작
    }

    public override void Exit()
    {
        Debug.Log("chasing 상태 나감");

        //애니메이션 종료
    }

    public override void Update()
    {
        Debug.Log("chasing 상태 중");

        if(!IsInChaseRange())
        {
            stateMachine.ChangeState(stateMachine.idleState);
            return;
        }
        //else if 공격 범위내 이면 공격 state로 전환
    }

    protected bool IsInAttackRange()
    {
        float playerDistanceSqr=(stateMachine.target.transform.position-stateMachine.monster.transform.position).sqrMagnitude;
         return playerDistanceSqr <= stateMachine.monster.data.AttackRange * stateMachine.monster.data.AttackRange;
    }
}
