using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;


public class MonsterBaseState : IState
{
 
    protected MonsterStateMachine stateMachine;
    protected readonly MonsterSO data;
    protected readonly float chasingRange;
    protected readonly float attackRange;
    
    public MonsterBaseState(MonsterStateMachine monsterStateMachine)
    {
        stateMachine=monsterStateMachine;
        data= stateMachine.monster.data;
        chasingRange= stateMachine.monster.data.PlayerChasingRange;
        attackRange= stateMachine.monster.data.AttackRange;
    }

    public virtual void Enter()
    {
        
    }

    public virtual void Exit()
    {
        
    }

    public virtual void Update()
    {
        
    }
    protected void StartAnimation(int animationHash)
    {
        stateMachine.monster.animator.SetBool(animationHash,true);
    }
     protected void StopAnimation(int animationHash)
    {
        stateMachine.monster.animator.SetBool(animationHash,false);
    }

      protected float GetNormalizedTime(Animator animator, string tag)
    {
        AnimatorStateInfo currentInfo = animator.GetCurrentAnimatorStateInfo(0);
        AnimatorStateInfo nextInfo = animator.GetNextAnimatorStateInfo(0);

        if (animator.IsInTransition(0) && nextInfo.IsTag(tag))
        {
            return nextInfo.normalizedTime;
        }
        else if (!animator.IsInTransition(0) && currentInfo.IsTag(tag))
        {
            return currentInfo.normalizedTime;
        }
        else
        {
            return 0f;
        }
    }
   

    protected bool IsInRange(float range)
    {
        RaycastHit hit;
        
        //Debug.DrawRay(stateMachine.monster.transform.position,stateMachine.monster.transform.forward*range, Color.green);

        if(Physics.Raycast(stateMachine.monster.transform.position,stateMachine.monster.transform.forward,out hit,range,1<<6))
        {
            stateMachine.monster.Target=hit.transform.gameObject.GetComponent<IDamageable>();
            return true;
        }
        
        return false;
    }
}
