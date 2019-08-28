using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float[] spawnBoundaries;
    public float speed = 2f;
    public GameObject player;
    public float closeEnough;

    public float wait;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(this.spawnBoundaries.Length);
        Debug.Log(this.spawnBoundaries[0]);
        Debug.Log(this.spawnBoundaries[1]);
        Debug.Log(this.spawnBoundaries[2]);
        Debug.Log(this.spawnBoundaries[3]);
    }

    // moves the enemy towards the player
    public void FollowPlayer()
    {
        this.transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.fixedDeltaTime);
    }

    //Randomly picking a point for the enemy to start at using arbitrary consrtaints
    // ideally this would be the size of the level or whereve we want these to spawn
    public Vector3 RandomPointInBounds()
    {

        //Random.Range is INCLUSIVE
        //i know this is a weird way to do it but fight me
        var randomX = Random.Range(this.spawnBoundaries[0], this.spawnBoundaries[1]); //length of the horizontal spawn box
        var randomY = Random.Range(this.spawnBoundaries[2], this.spawnBoundaries[3]); //length of the vertical spawn box

        return new Vector3(randomX, randomY, 0);
    }

}
