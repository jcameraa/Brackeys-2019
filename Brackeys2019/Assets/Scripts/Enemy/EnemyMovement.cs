using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : EnemyController
{
    private bool hasSeen = false;
    private int newPoint;
    private int health;


    public Transform[] walkBetween;
    
    void Start() 
    {
        // picks a random point to have the enemy start at
        transform.position = RandomPointInBounds();

        //picks a "random" point for the enemy to move to
        newPoint = Random.Range(0, 2);
    }
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        // checks to see if the player is within sight
        if (other.gameObject.tag == "Player") 
        {
            hasSeen = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // if the player has been seen then either move towards the player or attack
        if (hasSeen)
        {
            // stops the random movement of the bois so they follow the player forever
            // if the enemy is within a certain range stop following and attack
            if (Vector2.Distance(transform.position, player.transform.position) > closeEnough)
            {
                FollowPlayer();
            }
            else
            {
                //attack Player (probably just an animation)
                //decrease player health 
                //attack cool down (or give player a few invinsiable frames?)
            }
        }
        else
        {
            this.transform.position = Vector2.MoveTowards(transform.position, walkBetween[newPoint].position, speed * Time.deltaTime);
        }

        if (this.transform.position.x == walkBetween[newPoint].position.x && 
            this.transform.position.y == walkBetween[newPoint].position.y)
        {
            newPoint = MoveToNewLocation();
        }
    }

    int MoveToNewLocation() 
    {
        //sets var to be the current point
        var num = newPoint;

        switch (num)
        {
            case 0:
                num = 1;
                break;
            case 1:
                num = 2;
                break;
            case 2:
                num = 0;
                break;
            default:
                num = Random.Range(0, 2);
                break;
        }

        return num;
    }

    public void takeDamage(int damageTaken)
    {
        Debug.Log("enemy takes damage ");

        health -= damageTaken; 

        if (health <= 0)
        {
            Debug.Log("Enemy dead :)");
            // delete enemy
        }
    }
}
