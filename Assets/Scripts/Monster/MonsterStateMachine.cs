using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStateMachine : StateMachine
{
    public Monster monster{get;}
    public GameObject target{get; private set;}
    public MonsterIdleState idleState{get; private set;}
    public MonsterChasingState chasingState{get; private set;}
    public MonsterAttackState attackState{get; private set;}

    public Vector2 movementInput{get;set;}
    public float movementSpeed{get;private set;}
    public float rotationDamping{get;set;}
    public float movementSpeedModifier{get;set;}


    public MonsterStateMachine(Monster _monster)
    {
        this.monster =_monster;

        target= GameObject.FindGameObjectWithTag("Player");

        idleState = new MonsterIdleState(this);
        chasingState = new MonsterChasingState(this);
        //attackState = new MonsterAttackState(this);

        movementSpeed= monster.data.idleSpeed;
    }
    
}
