using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordStats : MonoBehaviour
{
    // the miniume damage this weapon can deal
    public int minDamage;

    // the maximum damage this weapon could deal 
    public int maxDamage;

    // choses a damage between the min and max for the 
    // sword to deal durning that attack
    public int choseDamage()
    {
        int curDamage = Random.Range(minDamage, maxDamage);

        return curDamage; 
    }
}
