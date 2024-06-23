using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MonsterAnimationData
{
    [SerializeField]private string idleParameterName="Idle";
    [SerializeField]private string runParameterName="Run";
    [SerializeField]private string attackParameterName="Attack";

    public int IdleParameterHash{get;private set;}
    public int RunParameterHash{get;private set;}
    public int AttackParameterHash{get;private set;}

    public void Initialize()
    {
        IdleParameterHash=Animator.StringToHash(idleParameterName);
        RunParameterHash=Animator.StringToHash(runParameterName);
        AttackParameterHash=Animator.StringToHash(attackParameterName);
    }
}
