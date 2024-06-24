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
       // Debug.Log("�߰�");
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

        if(!IsInChasingRange())//?��?�� ?��간이 �??���? 추격 ?��?�� ?��?��
        {
            timeSinceLastUpdate += Time.deltaTime;
            if(timeSinceLastUpdate >= updateInterval)
            {
                timeSinceLastUpdate = 0;
                stateMachine.ChangeState(stateMachine.idleState);
            }
            return;
        }
        else if(IsInAttackRange())//공격 �??�� 범위 ?��?��?���?  ?��?�� �?�?
        {
            stateMachine.monster.navMeshAgent.velocity=Vector3.zero;
            stateMachine.navMeshAgent.speed=data.idleSpeed;
            stateMachine.ChangeState(stateMachine.attackState);
        }
        else
        {
            timeSinceLastUpdate = 0;
        }
    }

    public void AccelerationChasing()//�??��?���? 쫓아?��?�� 경우
    {
        stateMachine.navMeshAgent.speed++;
        stateMachine.navMeshAgent.speed= Mathf.Min(stateMachine.navMeshAgent.speed,data.chasingSpeed);
        stateMachine.navMeshAgent.SetDestination(stateMachine.target.transform.position);
    }
    public void CheckSightChaing()//?��?�� 감�??�? 쫓아?��?��경우
    {
        if(stateMachine.monster.canOperate==true)
        {
            stateMachine.navMeshAgent.speed=stateMachine.monster.data.chasingSpeed;
            stateMachine.navMeshAgent.SetDestination(stateMachine.target.transform.position);
        }
        
    }
}
