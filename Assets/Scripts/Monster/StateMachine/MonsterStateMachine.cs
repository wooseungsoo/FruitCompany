using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class MonsterStateMachine : StateMachine
{
    public Monster monster{get;}
    public GameObject target{get; private set;}
    public MonsterIdleState idleState{get; private set;}
    public MonsterChasingState chasingState{get; private set;}
    public MonsterAttackState attackState{get; private set;}
    public NavMeshAgent navMeshAgent;

    public float movementSpeed{get;private set;}

    


    public MonsterStateMachine(Monster _monster)
    {
        this.monster =_monster;

        target= GameObject.FindGameObjectWithTag("Player");
        idleState = new MonsterIdleState(this);
        chasingState = new MonsterChasingState(this);
        attackState = new MonsterAttackState(this);
        
        navMeshAgent=monster.navMeshAgent;
        movementSpeed= monster.data.idleSpeed;

    
    }
    
}
