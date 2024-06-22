using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public MonsterSO data;
    private MonsterStateMachine stateMachine;
    public NavMeshAgent navMeshAgent{get;private set;}
    public Action onAttack;
    public Action onChasing;
    public Action onIdle;

    private void Awake() 
    {
        navMeshAgent=GetComponent<NavMeshAgent>();
        stateMachine= new MonsterStateMachine(this);
    }

    private void Start() 
    {
        SetAction();
        stateMachine.ChangeState(stateMachine.idleState);
    }
    private void Update() 
    {
        stateMachine.Update();
    }

    protected void SetAction()
    {

    }
}
