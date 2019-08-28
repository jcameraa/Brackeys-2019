using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public PlayerStats player;

    private void Start()
    {
        player = GetComponentInParent<PlayerStats>();
    }

    /* private void OnCollisionEnter(Collision collision)
     {
         Debug.Log("At player attack");
         collision.gameObject.GetComponent<EnemyController>().takeDamage(player.curSword.choseDamage());
     } */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("At player attack");
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("I am at the enemy");
            collision.gameObject.GetComponent<EnemyMovement>().takeDamage(player.curSword.choseDamage());
        }
    }
}
