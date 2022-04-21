using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    private Image playerHealth_UI, enemyHealth_UI;

    void Awake()
    {
        playerHealth_UI = GameObject.FindWithTag(Tags.PLAYER_HEALTH_UI).GetComponent<Image>();
        enemyHealth_UI = GameObject.FindWithTag(Tags.ENEMY_HEALTH_UI).GetComponent<Image>();
    }

    public void DisplayHealth(float value, bool isPlayer)
    {
        value /= 100f;

        if(value < 0f)
        {
            value = 0f;
        }
                
        if (isPlayer)
        {
            playerHealth_UI.fillAmount = value;
        } else
        {
            enemyHealth_UI.fillAmount = value;
        }     
    }
}
