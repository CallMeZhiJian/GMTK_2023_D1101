using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private AudioClip clickButtonSFX;
    [SerializeField] private AudioClip BGM;

    public void playGame()
    {
        SceneManager.LoadScene("TutorialScene");
        SoundManager.instance.PlaySound(clickButtonSFX);
    }
    
    public void quitGame()
    {
        Application.Quit();
        SoundManager.instance.PlaySound(clickButtonSFX);
    }

    public void pauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
        SoundManager.instance.pauseSound();
    }

    public void resumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        SoundManager.instance.PlaySound(clickButtonSFX);
        SoundManager.instance.resumeSound();
    }

    public void restartGame()
    {
        SceneManager.LoadScene("GameScene");
        SoundManager.instance.PlaySound(clickButtonSFX);
        SoundManager.instance.SwitchSound(BGM);
    }

    public void backToMainMenu()
    {
        SceneManager.LoadScene("MainScene");
        SoundManager.instance.PlaySound(clickButtonSFX);
        SoundManager.instance.SwitchSound(BGM);
    }
}
