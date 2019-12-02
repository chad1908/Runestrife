using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FollowingProjectile : MonoBehaviour
{
    //The Enemy this projectile needs to follow
    public Enemy enemyToFollow;

    //Speed at which this projectile moves, in units per second
    public float moveSpeed = 15;

    private void Update()
    {
        //If the enemy this projectile is following doesn't exist anymore, it should destroy itself
        if (enemyToFollow == null)
        {
            Destroy(gameObject);
        }
        else
        {
            //As long as there's still a target enemy, look at the target and move towards it
            transform.LookAt(enemyToFollow.transform);
            GetComponent<Rigidbody>().velocity = transform.forward * moveSpeed;
        }
    }

    //If this projectile hits an object, and it's the enemy it's following, then call OnHitEnemy()
    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>() == enemyToFollow)
        {
            OnHitEnemy();
        }
    }

    //this is an abstract method that need to be implemented by the derived class
    protected abstract void OnHitEnemy();
}
