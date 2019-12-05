using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : FollowingProjectile
{
    //amount of damage that gets inflited to the enemy on impact
    public float damage;

    //Override FollowingProjectile's OnHitEnemy() method
    protected override void OnHitEnemy()
    {
        //Deal damage to the enemy and destroy the projectile
        enemyToFollow.TakeDamage(damage);
        Destroy(gameObject);
    }
}
