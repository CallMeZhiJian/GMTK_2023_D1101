using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource effectSource;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        effectSource.PlayOneShot(clip);
    }

    public void SwitchSound(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void pauseSound()
    {
        musicSource.Pause();
        effectSource.Pause();
    }

    public void resumeSound()
    {
        musicSource.UnPause();
        effectSource.UnPause();
    }

    public void changeVolumeBGM(float value)
    {
        musicSource.volume = value;
    }

    public void changeVolumeSFX(float value)
    {
        effectSource.volume = value;
    }
}
