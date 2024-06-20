using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStateMachine : MonoBehaviour
{
    public Monster monster{get;}
    public GameObject target{get; private set;}
    public MonsterIdleState idleState{get; private set;}
    public MonsterChasingState chasingState{get; private set;}
    public MonsterAttackState attackState{get; private set;}

    public Vector2 movementInput{get;set;}
    public float movementSpeed{get;private set;}
    //public float rotatin?{get;set;}
    //public float modifier?{get;set;}


    public MonsterStateMachine(Monster _monster)
    {
        this.monster =_monster;
        //타겟 
        // idleState = new MonsterIdleState(this);
        // chasingState = new MonsterChasingState(this);
        // attackState = new MonsterAttackState(this);
    }
    
}
