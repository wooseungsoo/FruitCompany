using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttackState : MonsterBaseState
{
    public float updateInterval;
    private float timeSinceLastUpdate;
    public MonsterAttackState(MonsterStateMachine monsterStateMachine) : base(monsterStateMachine)
    {
        updateInterval=stateMachine.monster.data.attackDealy;
    }

    public override void Enter()
    {
        Debug.Log("공격");
        timeSinceLastUpdate=0;
        targetInfo=stateMachine.target.GetComponent<IDamageable>();
        StartAnimation(stateMachine.monster.AnimationData.AttackParameterHash);
    }

    public override void Exit()
    {
        StopAnimation(stateMachine.monster.AnimationData.AttackParameterHash);
    }
    public override void Update()
    {
        timeSinceLastUpdate += Time.deltaTime;
        base.Update();

        if (IsInAttackRange())
        {
            if(timeSinceLastUpdate >= updateInterval)
            {
                if(stateMachine.monster.onAttack!=null)
                {
                    stateMachine.monster.onAttack.Invoke();
                }
                else
                {
                    Attack();
                }
                timeSinceLastUpdate = 0f;
            }

        }
        else
        {
            if (!IsInChasingRange())
            {
                stateMachine.ChangeState(stateMachine.chasingState);
                return;
            }
        }
    }

    void Attack()
    {
        if(stateMachine.monster.canOperate==true)
        targetInfo.TakePhysicalDamage(stateMachine.monster.data.attackDamage);
    }


}
