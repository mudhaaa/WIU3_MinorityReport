using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/EnemyStats")]
public class EnemyStats : ScriptableObject
{
    public float moveSpeed = 1f;
    public float lookRange = 8f;

    public float attackRange = 1.5f;
    public float attackRate = 1f;
    public int attackDamage = 10;

    public float searchDuration = 4f;
    public float lookSphereCastRadius = 2f;
    public float MaxHealth = 100;
}
