using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttackState : MonsterBaseState
{
    public float updateInterval = 1f;
    private float timeSinceLastUpdate;
    public MonsterAttackState(MonsterStateMachine monsterStateMachine) : base(monsterStateMachine)
    {
        
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
                Attack();
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
        //데이터에서 데미지 가져오고 플레이어 체력 차감
        targetInfo.TakePhysicalDamage(stateMachine.monster.data.attackDamage);

    }


}
