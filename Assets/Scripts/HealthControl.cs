using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthControl : MonoBehaviour
{
    public int playerHealth = 3 ;
    public int currentHealth;

    [SerializeField] private AudioClip hurtSFX;
    [SerializeField] private AudioClip gameOverSFX;
    [SerializeField] private AudioClip gameOverBGM;
    [SerializeField] private Image[] hearts;
    

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = playerHealth;
        UpdateHealth();
    }

    // Update is called once per frame
    public void UpdateHealth()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].color = Color.red;
            }
            else
            {
                hearts[i].color = Color.grey;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        SoundManager.instance.PlaySound(hurtSFX);
        currentHealth = currentHealth - damage;
        UpdateHealth();
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            SoundManager.instance.PlaySound(gameOverSFX);
            SoundManager.instance.SwitchSound(gameOverBGM);
        }
       
        
    }
}
