using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttackState : MonsterBaseState
{
    public float updateInterval = 3f;
    private float timeSinceLastUpdate;
    public MonsterAttackState(MonsterStateMachine monsterStateMachine) : base(monsterStateMachine)
    {
        
    }

    public override void Enter()
    {
        Debug.Log("공격");

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

        if (IsInRange(attackRange))
        {
            if(timeSinceLastUpdate >= updateInterval)
            {
                Attack();
                timeSinceLastUpdate = 0f;
            }

        }
        else
        {
            if (IsInRange(chasingRange))
            {
                stateMachine.ChangeState(stateMachine.chasingState);
                return;
            }
            else 
            {
                stateMachine.ChangeState(stateMachine.idleState);
                return;
            }
        }
    }

    void Attack()
    {
        //데이터에서  데미지 가져오고 플레이어 스탯 차감헤야함
        stateMachine.monster.Target.TakePhysicalDamage(stateMachine.monster.data.attackDamage);
    }


}
