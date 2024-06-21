using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttackState : MonsterBaseState
{
    public MonsterAttackState(MonsterStateMachine monsterStateMachine) : base(monsterStateMachine)
    {
        
    }

    public override void Enter()
    {
        Debug.Log("공격 상태 진입");
        //애니메이션 시작
    }

    public override void Exit()
    {
        Debug.Log("공격 상태 나감");

        //애니메이션 종료
    }
     public override void Update()
    {
        base.Update();

        //ForceMove();

        // float normalizedTime = GetNormalizedTime(stateMachine.Enemy.Animator, "Attack");
        // if (normalizedTime < 1f)
        // {
        //     if (normalizedTime >= stateMachine.Enemy.Data.ForceTransitionTime)
        //         TryApplyForce();

        // }
        // else
        // {
        //     if (IsInChasingRange())
        //     {
        //         stateMachine.ChangeState(stateMachine.ChasingState);
        //         return;
        //     }
        //     else
        //     {
        //         stateMachine.ChangeState(stateMachine.IdleState);
        //         return;
        //     }
        // }

    }


}
