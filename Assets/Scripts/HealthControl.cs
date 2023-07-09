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

    private Animator anim;
    

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = playerHealth;
        UpdateHealth();
        anim = GetComponent<Animator>();
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
        anim.SetTrigger("Hurt");
        currentHealth = currentHealth - damage;
        UpdateHealth();
        if (currentHealth <= 0)
        {
            StartCoroutine(DeathAnimation());
            
            SoundManager.instance.PlaySound(gameOverSFX);
            SoundManager.instance.SwitchSound(gameOverBGM);  
        }
        anim.SetTrigger("DoneAction");
    }

    IEnumerator DeathAnimation()
    {
        anim.SetTrigger("Death");
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
