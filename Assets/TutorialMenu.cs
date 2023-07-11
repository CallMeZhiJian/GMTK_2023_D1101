using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialMenu : MonoBehaviour
{
    [SerializeField] private AudioClip clickButtonSFX;
    public void nextGame()
    {
        SceneManager.LoadScene("GameScene");
        SoundManager.instance.PlaySound(clickButtonSFX);
    }

}
