using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthControl : MonoBehaviour
{
    public int playerHealth = 3 ;
    public int currentHealth;

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
        currentHealth = currentHealth - damage;
        UpdateHealth();
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
       
        
    }
}
