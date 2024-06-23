using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterIdleState : MonsterBaseState
{
    public float updateInterval = 3f;
    private float timeSinceLastUpdate;
    public MonsterIdleState(MonsterStateMachine monsterStateMachine) : base(monsterStateMachine)
    {

    }

    public override void Enter()
    {
        Debug.Log("IDLE");

        stateMachine.navMeshAgent.speed= data.idleSpeed;
        StartAnimation(stateMachine.monster.AnimationData.IdleParameterHash);
    }

    public  override void Exit()
    {
        StopAnimation(stateMachine.monster.AnimationData.IdleParameterHash);
    }

    public override void Update()
    {
        timeSinceLastUpdate += Time.deltaTime;

        base.Update();

        
        if (timeSinceLastUpdate >= updateInterval) //n초 마다 랜덤 배회
        {   
            stateMachine.navMeshAgent.SetDestination(GetRandomPosition());
            timeSinceLastUpdate = 0f;
        }
    

        if(IsInRange(chasingRange))
        {
            stateMachine.ChangeState(stateMachine.chasingState);
            return;
        }
    }

    Vector3 GetRandomPosition()
    {
        Vector3 randomDirection = Random.insideUnitSphere*20f; // 반경에 랜덤으로 구 배치
        randomDirection+= stateMachine.monster.gameObject.transform.position;

        NavMeshHit hit;


        if(NavMesh.SamplePosition(randomDirection,out hit,20f,NavMesh.AllAreas))
        {
            return  hit.position;
        }
        else
        {
            return stateMachine.monster.gameObject.transform.position;
        }
    }


}
