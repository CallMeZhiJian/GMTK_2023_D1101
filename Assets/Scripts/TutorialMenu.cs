using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialMenu : MonoBehaviour
{
    [SerializeField] private AudioClip clickButtonSFX;
    [SerializeField] private Animator tutorialAnim;
    
    private void Start()
    {
        StartCoroutine(startScene());
    }

    public void nextGame()
    {
        StartCoroutine(endScene());
        tutorialAnim.SetBool("isOpened", false);
        SoundManager.instance.PlaySound(clickButtonSFX);
    }

    IEnumerator startScene()
    {
        yield return new WaitForSeconds(0.5f);
        tutorialAnim.SetBool("isOpened", true);
    }

    IEnumerator endScene()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("GameScene");
    }
}
