using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The class used to control health and attacking
// for the player. Probably could have been combined
// with the controller but I did not want to :)
public class PlayerStats : MonoBehaviour
{
    // The maxium health a player is able to have
    [SerializeField] private int maxHealth;

    // The current health the player is at
    [SerializeField] private int curHealth;

    // The radius oh how long the player's hit is
    [SerializeField] private int hitRange;

    // The current sword equipped
    [SerializeField] private SwordStats curSword;

    // The list of enemies that were attacked durning any hit
    private Collider2D[] enemiesHit; 

    private void Start()
    {
        enemiesHit = new Collider2D[100];
        curHealth = maxHealth;
    }

    // applies the damage from the enemy that attacked
    public void takeDamage(int damage)
    {
        curHealth -= damage;

        if (curHealth <= 0)
        {
            Debug.Log("You lose!");
        }
    }

    // Adds health equal to the number to be gained 
    // or to the max health, whichever comes first
    public void gainHealth(int toGain)
    {
        for (int i = toGain; toGain == 0; i--)
        {
            if (curHealth != maxHealth)
            {
                curHealth++;
            }
            else break;
        }
    }

    // Attacks all enemies within a certain radius of the player
    public void attackEnemies()
    {
        /*
        Physics2D.OverlapCircleNonAlloc(this.transform.position, hitRange, enemiesHit);

        Debug.Log("Name " + enemiesHit[0]);

        foreach(Collider2D enemy in enemiesHit)
        {
            enemy.GetComponent<EnemyController>().takeDamage(curSword.choseDamage());
        }
        enemiesHit = null;
        */
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("AHHHH");
            attackEnemies();
        }
    }
}
