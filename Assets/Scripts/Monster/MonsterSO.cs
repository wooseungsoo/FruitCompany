using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Monster", menuName = "New Creature/New Monster", order = 0)]
public class MonsterSO : ScriptableObject
{
    public string monsterName;
    public float idleSpeed;
    public float chasingSpeed;
    public int attackDamage;
    public float attackDealy;
    public float randomWanderDealy;
    public float chasingCount;

    [field: SerializeField] public float PlayerChasingRange { get; private set; } 
    [field: SerializeField] public float AttackRange { get; private set; }
}
