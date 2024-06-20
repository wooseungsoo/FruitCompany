using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Monster", menuName = "New Creature/New Monster", order = 0)]
public class MonsterSO : ScriptableObject
{
    public string monsterName;
    public float idleSpeed;
    public float chasingSpeed;
    public float attackDamage;

    [field: SerializeField] public float PlayerChasingRange { get; private set; } = 10f;
    [field: SerializeField] public float AttackRange { get; private set; } = 1.5f;
}
