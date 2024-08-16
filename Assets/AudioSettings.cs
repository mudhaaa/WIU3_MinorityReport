using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider masterVolumeSlider;
    [SerializeField] private Slider bgmVolumeSlider;
    [SerializeField] private Slider sfxVolumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        masterVolumeSlider.value = 0.5f;
        bgmVolumeSlider.value = 0.5f;
        sfxVolumeSlider.value = 0.5f;

    }

    // Update is called once per frame
    void Update()
    {
        SetBGMVolume();
        SetSFXVolume();
        SetMasterVolume();
    }

    public void SetMasterVolume()
    {
        // -40 is the minimum volume that can be heard
        // The following is to calculate the volume to be in the range of -40 to 0 based on the slider value
        float volume = (masterVolumeSlider.value * 40 - 40);
        // Set the mixer master volume to the slider value
        mixer.SetFloat("MasterVolume", volume);
    }

    public void SetSFXVolume()
    {
        // -40 is the minimum volume that can be heard
        // The following is to calculate the volume to be in the range of -40 to 0 based on the slider value
        float volume = (sfxVolumeSlider.value * 40 - 40);
        // Set the mixer master volume to the slider value
        mixer.SetFloat("sfxVolume", volume);
    }

    public void SetBGMVolume()
    {
        // -40 is the minimum volume that can be heard
        // The following is to calculate the volume to be in the range of -40 to 0 based on the slider value
        float volume = (bgmVolumeSlider.value * 40 - 40);
        // Set the mixer master volume to the slider value
        mixer.SetFloat("bgmVolume", volume);
    }

    public void Show()
    {
        this.gameObject.SetActive(!this.gameObject.activeSelf);
    }
}
