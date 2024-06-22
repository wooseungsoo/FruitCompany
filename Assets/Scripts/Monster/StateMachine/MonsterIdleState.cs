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
        stateMachine.navMeshAgent.speed= data.idleSpeed;
        //아래에 애니메이션
    }

    public  override void Exit()
    {
        Debug.Log("Idle 상태 나감");

        //애니메이션 스탑
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
