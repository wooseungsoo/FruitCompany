using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Monster", menuName = "New Creature/New Monster", order = 0)]
public class MonsterSO : ScriptableObject
{
    public string monsterName="";
    public float minSpeed;
    public float maxSpeed;
    public float attackDamage;
}
