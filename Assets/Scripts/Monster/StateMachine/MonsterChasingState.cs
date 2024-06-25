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

       
        if(IsInAttackRange())//���� ���� ���� ��
        {
            stateMachine.monster.navMeshAgent.velocity=Vector3.zero;
            stateMachine.navMeshAgent.speed=data.idleSpeed;
            stateMachine.ChangeState(stateMachine.attackState);
        }
        if(!IsInChasingRange())//�߰� �������� ����� ��
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

    public void AccelerationChasing()//�߰����϶� �ӵ��� ���� ������
    {
        stateMachine.navMeshAgent.speed+=Time.deltaTime;
        stateMachine.navMeshAgent.speed= Mathf.Min(stateMachine.navMeshAgent.speed,data.chasingSpeed);
        stateMachine.navMeshAgent.SetDestination(stateMachine.target.transform.position);
    }
    public void CheckSightChaing()//�÷��̾��� �þ߾��� �ƴҶ� ������
    {
        if(stateMachine.monster.canOperate==true)
        {
            stateMachine.navMeshAgent.speed=stateMachine.monster.data.chasingSpeed;
            stateMachine.navMeshAgent.SetDestination(stateMachine.target.transform.position);
        }
        
    }
}
