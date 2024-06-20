using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public MonsterSO data;
    private MonsterStateMachine stateMachine;
    public CharacterController controller{get;private set;}

    private void Awake() 
    {
        stateMachine= new MonsterStateMachine(this);
        controller= GetComponent<CharacterController>();
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
