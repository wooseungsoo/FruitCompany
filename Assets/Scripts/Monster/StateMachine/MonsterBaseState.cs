using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;


public class MonsterBaseState : IState
{
 
    protected MonsterStateMachine stateMachine;
    protected readonly MonsterSO data;
    
    public MonsterBaseState(MonsterStateMachine monsterStateMachine)
    {
        stateMachine=monsterStateMachine;
        data= stateMachine.monster.data;
    }

    public virtual void Enter()
    {
        
    }

    public virtual void Exit()
    {
        
    }

    public virtual void Update()
    {
        //Move();
    }

    // private void Move()
    // {
    //     Vector3 movementDirection=GetMovementDirection();
    //     // Rotate(movementDirection);
    //    //Move(movementDirection);
        
    // }
    // void Move(Vector3 movementDirection)
    // {
    //     float movementSpeed= GetMovementSpeed();
    //     stateMachine.monster.controller.Move(movementDirection*movementSpeed);//조금다름
    // }

    // Vector3 GetMovementDirection()
    // {
    //     Vector3 dir = (stateMachine.target.transform.position-stateMachine.monster.transform.position).normalized;
    //     return dir;
    // }

    // private float GetMovementSpeed()
    // {
    //     float movementSpeed = stateMachine.movementSpeed*stateMachine.movementSpeedModifier;
    //     return movementSpeed;
    // }

    protected bool IsInChaseRange()
    {
        RaycastHit hit;
        
        Debug.DrawRay(stateMachine.monster.transform.position,stateMachine.monster.transform.forward*stateMachine.monster.data.PlayerChasingRange, Color.green);

        if(Physics.Raycast(stateMachine.monster.transform.position,stateMachine.monster.transform.forward,out hit,stateMachine.monster.data.PlayerChasingRange))
        {
            Debug.Log(hit.transform.gameObject.name);
            return true;
        }
        
        return false;
    }
}
