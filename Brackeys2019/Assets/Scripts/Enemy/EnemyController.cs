using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private bool hasSeen = false;
    private int health;

    public float speed = 2f;
    public float closeEnough;
    public GameObject player;
    
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
        Debug.Log("Distance: " + Vector2.Distance(transform.position, player.transform.position));
        
        //if the player has been seen then either move towards the player or attack
        if (hasSeen)
        {
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
    }

    // moves the enemy towards the player
    void FollowPlayer() 
    {
        this.transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.fixedDeltaTime);
    }
}
