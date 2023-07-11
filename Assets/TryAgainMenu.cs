using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TryAgainMenu : MonoBehaviour
{
    [SerializeField] private AudioClip clickButtonSFX;
    [SerializeField] private AudioClip restartBGM;
    public void tryAgainGame()
    {
        SceneManager.LoadScene("GameScene");
        SoundManager.instance.PlaySound(clickButtonSFX);
        SoundManager.instance.SwitchSound(restartBGM);
    }

}