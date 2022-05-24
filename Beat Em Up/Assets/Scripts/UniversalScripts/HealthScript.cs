using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float health = 100f;

    private CharacterAnimation animationScript;
    private EnemyMovement enemyMovement;

    private bool characterDied;

    public bool is_Player;

    private HealthUI health_UI, playerHealth_UI, enemyHealth_UI;

    void Awake()
    {
        animationScript = GetComponentInChildren<CharacterAnimation>();

        health_UI = GetComponent<HealthUI>();
    }

    public void ApplyDamage(float damage, bool knockDown)
    {
        if (characterDied)
        {
            return;
        }

        health -= damage;

        // display health UI
        health_UI.DisplayHealth(health, is_Player);
        
        if (health <= 0f)
        {
            animationScript.Death();
            characterDied = true;

            // if is player deactivate enemy script
            if(is_Player)
            {
                GameObject.FindWithTag(Tags.ENEMY_TAG).GetComponent<EnemyMovement>().enabled = false;
                GameObject.FindWithTag(Tags.PLAYER_TAG).GetComponent<PlayerMovement>().enabled = false;
                GameObject.FindWithTag(Tags.PLAYER_TAG).GetComponent<PlayerAttack>().enabled = false;
            }

            return;
        }


        if (!is_Player)
        {
            if (knockDown)
            {
                if(Random.Range(0, 2) > 0)
                {
                    animationScript.KnockDown();
                } 
            } else
            {
                if(Random.Range(0, 3) > 1)
                {
                    animationScript.Hit();
                }
            }
        } // if is not player

    } // apply damage
}
