using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider sliderBGM;
    [SerializeField] private Slider sliderSFX;

    void Start()
    {
        SoundManager.instance.changeVolumeBGM(PlayerPrefs.GetFloat("BGMslider"));
        sliderBGM.value = PlayerPrefs.GetFloat("BGMslider");
        sliderBGM.onValueChanged.AddListener(val => SoundManager.instance.changeVolumeBGM(val));

        SoundManager.instance.changeVolumeSFX(PlayerPrefs.GetFloat("SFXslider"));
        sliderSFX.value = PlayerPrefs.GetFloat("SFXslider");
        sliderSFX.onValueChanged.AddListener(val => SoundManager.instance.changeVolumeSFX(val));
    }

    private void Update()
    {
        PlayerPrefs.SetFloat("BGMslider", sliderBGM.value);
        PlayerPrefs.SetFloat("SFXslider", sliderSFX.value);
    }
}
