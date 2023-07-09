using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioClip clickButtonSFX;
    public void playGame()
    {
        SceneManager.LoadScene("GameScene");
        SoundManager.instance.PlaySound(clickButtonSFX);
    }
    
    public void quitGame()
    {
        Application.Quit();
        SoundManager.instance.PlaySound(clickButtonSFX);
    }
}
