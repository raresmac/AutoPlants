using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEntity : BaseEntity
{
    public Sprite pellet;

    protected override void OnRoundStart()
    {
        FindTarget();
    }

    public void Update()
    {
        if (!HasEnemy)
        {
            FindTarget();
        }

        if (IsInRange && !moving)
        {
            //In range for attack!
            if (canAttack)
            {
                Attack();
                LaunchProjectile();
                currentTarget.TakeDamage(baseDamage);
            }
        }
        else
        {
            GetInRange();
        }
    }

    private void LaunchProjectile(){
        GameObject bullet = Instantiate(new GameObject(), transform.position, Quaternion.identity);
        bullet.AddComponent<Projectile>().currentTarget = currentTarget;
        bullet.AddComponent<SpriteRenderer>().sprite = pellet;
        Rigidbody2D rigidBody = bullet.AddComponent<Rigidbody2D>();
        rigidBody.gravityScale = 0;
        rigidBody.velocity = (currentTarget.transform.position - transform.position).normalized * 5;
    }
}