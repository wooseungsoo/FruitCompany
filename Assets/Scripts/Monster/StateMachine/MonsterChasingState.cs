using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterChasingState : MonsterBaseState
{
    public float updateInterval = 3f;
    private float timeSinceLastUpdate;
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

        if(!IsInChaseRange())
        {
            timeSinceLastUpdate += Time.deltaTime;
            if(timeSinceLastUpdate >= updateInterval)
            {
                timeSinceLastUpdate = 0;
                stateMachine.ChangeState(stateMachine.idleState);
            }
            return;
        }
        else if(IsInAttackRange())
        {
            Debug.Log("공격 가능 범위");
            stateMachine.ChangeState(stateMachine.chasingState);
            stateMachine.monster.navMeshAgent.velocity=Vector3.zero;
        }
        else
        {
            timeSinceLastUpdate = 0;
        }
    }

    protected bool IsInAttackRange()
    {
        float playerDistanceSqr=(stateMachine.target.transform.position-stateMachine.monster.transform.position).sqrMagnitude;
        return playerDistanceSqr <= stateMachine.monster.data.AttackRange;
    }

    
}
