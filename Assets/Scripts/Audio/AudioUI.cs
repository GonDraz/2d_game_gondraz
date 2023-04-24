using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AudioUI : MonoBehaviour
{
    [SerializeField] private Slider musicSlider, sfxSlider;
    [SerializeField] private TextMeshProUGUI musicVolumeText, sfxVolumeText;
    [SerializeField] private Toggle musicToggle, sfxToggle;

    public void Start()
    {
        musicSlider.value = AudioManager.Instance.musicSource.volume;
        sfxSlider.value = AudioManager.Instance.sfxSource.volume;

        musicToggle.isOn = !AudioManager.Instance.musicSource.mute;
        sfxToggle.isOn = !AudioManager.Instance.sfxSource.mute;

        AudioManager.Instance.musicSource.mute = !musicToggle.isOn;
        AudioManager.Instance.sfxSource.mute = !sfxToggle.isOn;
        MusicVolume();
        SFXVolume();
    }
    public void ToggleMusic()
    {
        AudioManager.Instance.PlaySFX("Button");
        AudioManager.Instance.ToggleMusic();
    }

    public void ToggleSFX()
    {
        AudioManager.Instance.PlaySFX("Button");
        AudioManager.Instance.ToggleSFX();
    }

    public void MusicVolume()
    {
        AudioManager.Instance.MusicVolume(musicSlider.value);
        musicVolumeText.text = ((int)(musicSlider.value * 100)).ToString();
    }

    public void SFXVolume()
    {
        AudioManager.Instance.SFXVolume(sfxSlider.value);
        sfxVolumeText.text = ((int)(sfxSlider.value * 100)).ToString();
    }
}
