using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    private int damage;
    public float attackSpeed;

    private void Start()
    {
        InitVariables();
    }

    public void DealDamage(CharacterStats statsToDamage)
    {
        statsToDamage.TakeDamage(damage);
    }

    public override void Die()
    {
        base.Die();
        Destroy(gameObject);
    }

    public override void InitVariables()
    {
        maxHealth = 30;
        SetHealthTo(maxHealth);
        isDead = false;

        damage = 10;
        attackSpeed = 1.5f;
    }
}
