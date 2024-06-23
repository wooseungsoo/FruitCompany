using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public MonsterSO data;
    private MonsterStateMachine stateMachine;

    public Animator animator{get; private set;}

    [field: Header("Animations")]
    [field: SerializeField] public MonsterAnimationData AnimationData{get; private set;}

    public NavMeshAgent navMeshAgent{get;private set;}


    public Action onAttack;
    public Action onChasing;
    public Action onIdle;

    private void Awake() 
    {
        AnimationData.Initialize();


        navMeshAgent=GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
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
//      void OnDrawGizmos()
//    {
//         Transform transform= stateMachine.monster.transform;

//         Gizmos.DrawRay(transform.position,transform.forward*20);
//         Gizmos.DrawWireCube (transform.position + transform.forward *20,transform.lossyScale*3 );
//    }
}
