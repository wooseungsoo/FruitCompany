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
        Debug.Log("АјАн");
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
                Attack();
                timeSinceLastUpdate = 0f;
            }

        }
        else
        {
            if (!IsInAttackRange())
            {
                stateMachine.ChangeState(stateMachine.chasingState);
                return;
            }
        }
    }

    void Attack()
    {
       // Debug.Log(stateMachine.monster.canOperate);
        if(stateMachine.monster.canOperate==true)
        {
            targetInfo.TakePhysicalDamage(stateMachine.monster.data.attackDamage);

        }
    }


}
