using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterChasingState : MonsterBaseState
{
    float delayCount;
    public MonsterChasingState(MonsterStateMachine monsterStateMachine) : base(monsterStateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.navMeshAgent.speed= data.chasingSpeed;
        Debug.Log("chasing 상태 진입");
        //애니메이션 시작
    }

    public override void Exit()
    {
        Debug.Log("chasing 상태 나감");

        //애니메이션 종료
    }

    public override void Update()
    {
        stateMachine.navMeshAgent.SetDestination(stateMachine.target.transform.position);

        //추적에서 멀어진지 몇초가 지나면 일반적인 상태로 전환
        if(!IsInChaseRange())
        {
            stateMachine.ChangeState(stateMachine.idleState);
            return;
        }
        else if(IsInAttackRange())
        {
            Debug.Log("공격 가능 범위");
            stateMachine.navMeshAgent.velocity=Vector3.zero;
        }
        //else if 공격 범위내 이면 공격 state로 전환
    }

    protected bool IsInAttackRange()
    {
        float playerDistanceSqr=(stateMachine.target.transform.position-stateMachine.monster.transform.position).sqrMagnitude;
        return playerDistanceSqr <= stateMachine.monster.data.AttackRange;
    }

    IEnumerator ChasingCount()
    {

        return null;
    }
}
