using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Source: https://www.youtube.com/watch?v=ZzkIn41DFFo

public class healthBar : MonoBehaviour
{
    public Image healthBarFill;
    public Text healthText;
    public float health, maxHealth = 100;
    public GameObject BustedTank;
    float lerpSpeed;
    
    // Permet d'afficher les points de vies et d'animer la bar de vie lorsque des dégats sont influgés.
    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        healthText.text = health + "%";

        lerpSpeed = 3f * Time.deltaTime;

        HealthBarFiller();
        ColorChanger();

        if(health <= 0)
        {
            if (gameObject.CompareTag("Enemy"))
            {
                KillCounter.instance.setKill();
                Instantiate(BustedTank, gameObject.transform.position, Quaternion.Euler(gameObject.transform.rotation.eulerAngles));
                Destroy(gameObject);
            }
            
            if (gameObject.CompareTag("Player"))
            {
                Time.timeScale = 0;
                GameController.instance.gameEnded = true;
            }
        }
    }

    void ColorChanger()
    {
        Color healthColor = Color.Lerp(Color.red, Color.green, (health / maxHealth));
        healthBarFill.color = healthColor;
        if (gameObject.CompareTag("Player"))
        {
            healthText.color = healthColor;
        }
    }

    void HealthBarFiller()
    {
        healthBarFill.fillAmount = Mathf.Lerp(healthBarFill.fillAmount, health / maxHealth, lerpSpeed);
    }

    public void SetDamage(float damagePoints)
    {
        if (health > 0)
        {
            health -= damagePoints;
        }
    }
}
