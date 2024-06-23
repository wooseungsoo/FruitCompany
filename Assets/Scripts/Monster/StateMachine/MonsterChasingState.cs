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

        Debug.Log("추격");
        timeSinceLastUpdate = 0;
        stateMachine.navMeshAgent.speed= data.chasingSpeed;
        StartAnimation(stateMachine.monster.AnimationData.RunParameterHash);

    }

    public override void Exit()
    {
        StopAnimation(stateMachine.monster.AnimationData.RunParameterHash);
    }

    public override void Update()
    {
        stateMachine.navMeshAgent.SetDestination(stateMachine.target.transform.position);

        if(!IsInChasingRange())//일정 시간이 지나면 추격 상태 해제
        {
            timeSinceLastUpdate += Time.deltaTime;
            if(timeSinceLastUpdate >= updateInterval)
            {
                timeSinceLastUpdate = 0;
                stateMachine.ChangeState(stateMachine.idleState);
            }
            return;
        }
        else if(IsInAttackRange())//공격 가능 범위 안이라면  상태 변경
        {
            stateMachine.monster.navMeshAgent.velocity=Vector3.zero;
            stateMachine.ChangeState(stateMachine.attackState);
        }
    }

   
    
}
