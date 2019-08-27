using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The class used to control health and attacking
// for the player. Probably could have been combined
// with the controller but I did not want to :)
public class PlayerStats : MonoBehaviour
{
    // The current sword equipped
    public SwordStats curSword;

    // holds the attack collider as a child of this game object
    public GameObject swordAttack;

    // The maxium health a player is able to have
    [SerializeField] private int maxHealth;

    // The current health the player is at
    [SerializeField] private int curHealth;

    // The radius oh how long the player's hit is
    [SerializeField] private int hitRange;

    //True if in a state of attacking ,false otherwise
    private bool isAttacking;

    private void Start()
    {

        curHealth = maxHealth;
        isAttacking = false;
        swordAttack.GetComponent<BoxCollider2D>().enabled = false; 
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

    private IEnumerator disableCollider()
    {
        Debug.Log("Here very quickly");
        yield return new WaitForSeconds(1.5f);
        swordAttack.GetComponent<BoxCollider2D>().enabled = false;
        isAttacking = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown("space") && !isAttacking)
        {
            swordAttack.GetComponent<BoxCollider2D>().enabled = true;
            isAttacking = true;
            Debug.Log("AHHHH");
            StartCoroutine(disableCollider());
        }
    }
}
