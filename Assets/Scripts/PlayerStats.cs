using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int health;
    public int maxHealth;

    public int magicCharges;
    public int maxMagicCharges;
    public int magicChargeRate;

    public int stamina;
    public int maxStamina;
    public int staminaRate;

    public int damage;

    public bool isDead = false;

    public void TakeDamage(int damage)
    {
        health -= damage;
        CheckHealth();
    }


    void CheckHealth()
    {
        if (health <= 0)
        {
            health = 0;
            isDead = true;
        }
        if (health >= maxHealth)
            health = maxHealth;
    }

    void CheckMagic()
    {
        if (magicCharges <= 0)
            magicCharges = 0;
        if (magicCharges >= maxMagicCharges)
            magicCharges = maxMagicCharges;
    }

    void CheckStamina()
    {
        if (stamina <= 0)
            stamina = 0;
        if (stamina >= maxStamina)
            stamina = maxStamina;
        {

        }
    }
}
