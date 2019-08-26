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

    void Start()
    {
        var side_one = new Vector3(-16, 10.5f, 0);
        var side_two = new Vector3(-13.5f, 10.5f, 0);
        var side_three = new Vector3(-13.5f, 9f, 0);
        var side_four = new Vector3(-16, 9, 0);

        // Used to see the spawn area of enemies
        Debug.DrawLine(side_one, side_two, Color.red, 10000f, false);
        Debug.DrawLine(side_two, side_three, Color.cyan, 10000f, false);
        Debug.DrawLine(side_three, side_four, Color.green, 10000f, false);
        Debug.DrawLine(side_four, side_one, Color.magenta, 10000f, false);

        transform.position = RandomPointInBounds();
    }

    // randoms spawns an eneamy in a random place. Can easily be changed if we want to instansiate X 
    // amount of enemies insead of the easy way im doing it currently
    private Vector3 RandomPointInBounds()
    {
        var randomX = Random.Range(-16.1f, -13.5f);
        var randomY = Random.Range(9.1f, 10.5f);

        return new Vector3(randomX, randomY, 0);
    }

    // random moement of enemy, where they will bounce off eachother and boundries that I set
    private void RandomMovement() 
    {
        this.transform.position = Vector2.MoveTowards(transform.position, RandomPointInBounds(), speed * Time.fixedDeltaTime);
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
      //  Debug.Log("Distance: " + Vector2.Distance(transform.position, player.transform.position));
        
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
        else 
        {
            RandomMovement();
        }
    }

    // moves the enemy towards the player
    void FollowPlayer() 
    {
        this.transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.fixedDeltaTime);
    }
}
