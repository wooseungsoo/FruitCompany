using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterChasingState : MonsterBaseState
{
    public float updateInterval;
    private float timeSinceLastUpdate;
    public MonsterChasingState(MonsterStateMachine monsterStateMachine) : base(monsterStateMachine)
    {
        updateInterval=stateMachine.monster.data.chasingCount;
    }

    public override void Enter()
    {
       // Debug.Log("추격");
        timeSinceLastUpdate = 0;
        StartAnimation(stateMachine.monster.AnimationData.RunParameterHash);
    }

    public override void Exit()
    {
        StopAnimation(stateMachine.monster.AnimationData.RunParameterHash);
    }

    public override void Update()
    {
        if(stateMachine.monster.onChasing!=null)
        {
            stateMachine.monster.onChasing.Invoke();
        }
        else
        {
            stateMachine.navMeshAgent.SetDestination(stateMachine.target.transform.position);
        }

       
        if(IsInAttackRange())//공격 범위 내일 때
        {
            stateMachine.monster.navMeshAgent.velocity=Vector3.zero;
            stateMachine.navMeshAgent.speed=data.idleSpeed;
            stateMachine.ChangeState(stateMachine.attackState);
        }
        if(!IsInChasingRange())//추격 범위에서 벗어났을 떄
        {
            timeSinceLastUpdate += Time.deltaTime;
            if(timeSinceLastUpdate >= updateInterval)
            {
                timeSinceLastUpdate = 0;
                stateMachine.ChangeState(stateMachine.idleState);
            }
            return;
        }
        else
        {
            timeSinceLastUpdate = 0;
        }
    }

    public void AccelerationChasing()//추격중일때 속도가 점점 빨라짐
    {
        stateMachine.navMeshAgent.speed+=Time.deltaTime;
        stateMachine.navMeshAgent.speed= Mathf.Min(stateMachine.navMeshAgent.speed,data.chasingSpeed);
        stateMachine.navMeshAgent.SetDestination(stateMachine.target.transform.position);
    }
    public void CheckSightChaing()//플레이어의 시야안이 아닐때 움직임
    {
        if(stateMachine.monster.canOperate==true)
        {
            stateMachine.navMeshAgent.speed=stateMachine.monster.data.chasingSpeed;
            stateMachine.navMeshAgent.SetDestination(stateMachine.target.transform.position);
        }
        
    }
}
