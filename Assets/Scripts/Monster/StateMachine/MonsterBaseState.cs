using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;


public class MonsterBaseState : IState
{
 
    protected MonsterStateMachine stateMachine;
    protected readonly MonsterSO data;
    protected IDamageable targetInfo;

    
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

    protected bool IsInChasingRange()
    {
        Transform transform= stateMachine.monster.transform;

        RaycastHit hit;
       
        if(Physics.BoxCast(transform.position,transform.lossyScale*3,transform.forward,out hit,transform.rotation,10))
        {
            if((1<<hit.transform.gameObject.layer)==1<<6)
            {
                return true;
            }
        }
        

         // if(hit.transform.gameObject.CompareTag("Player"))
            // {
            //     return true;
            // }
        return false;
    }
    protected bool IsInAttackRange()
    {
        //Debug.Log(Vector3.Distance(stateMachine.target.transform.position,stateMachine.monster.transform.position));
        if(Vector3.Distance(stateMachine.target.transform.position,stateMachine.monster.transform.position)<=stateMachine.monster.data.AttackRange)
        {
            return true;
        }
        else
        {
            return false;

        }
        // float playerDistanceSqr = (stateMachine.target.transform.position - stateMachine.monster.transform.position).sqrMagnitude;
        // Debug.Log("**"+stateMachine.monster.data.AttackRange*stateMachine.monster.data.AttackRange);
        // Debug.Log("playerDistanceSqr"+playerDistanceSqr);
       // return playerDistanceSqr <= stateMachine.monster.data.AttackRange*stateMachine.monster.data.AttackRange;


    }
}
