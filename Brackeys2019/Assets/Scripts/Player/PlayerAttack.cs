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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("At player attack");
        collision.gameObject.GetComponent<EnemyController>().takeDamage(player.curSword.choseDamage());
    }
}
