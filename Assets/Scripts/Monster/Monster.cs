using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public MonsterSO data;
    private MonsterStateMachine stateMachine;
    public CharacterController controller{get;private set;}
    public NavMeshAgent navMeshAgent{get;private set;}

    private void Awake() 
    {
        controller= GetComponent<CharacterController>();
        navMeshAgent=GetComponent<NavMeshAgent>();

        stateMachine= new MonsterStateMachine(this);
    }

    private void Start() 
    {
        
        stateMachine.ChangeState(stateMachine.idleState);
    }
    private void Update() 
    {
        stateMachine.Update();
    }
}
