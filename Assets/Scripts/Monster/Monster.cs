using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public MonsterSO data;
    private MonsterStateMachine stateMachine;

    private void Awake() 
    {
        stateMachine= new MonsterStateMachine(this);
    }
}
