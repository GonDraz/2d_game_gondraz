using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;
    [SerializeField] private Slider musicSlider,sfxSlider;
    [SerializeField] private TextMeshProUGUI musicVolumeText,sfxVolumeText;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        MusicVolume();
        SFXVolume();
        PlayMusic("Theme");
    }

    public void PlayMusic(string name)
    {
        Sound sound = Array.Find(musicSounds, x => x.name == name);

        if (sound == null)
        {
            Debug.Log("Music Sound not found: "+ name);
        }
        else
        {
            musicSource.clip = sound.audioClip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound sound = Array.Find(sfxSounds, x => x.name == name);

        if (sound == null)
        {
            Debug.Log("SFX Sound not found: " + name);
        }
        else
        {
            sfxSource.PlayOneShot(sound.audioClip);
        }
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }    

    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }

    public void MusicVolume()
    {
        musicSource.volume = musicSlider.value;
        musicVolumeText.text = ((int)musicSlider.value).ToString();
    }

    public void SFXVolume()
    {
        sfxSource.volume = sfxSlider.value;
        sfxVolumeText.text = ((int)sfxSlider.value).ToString();
    }

}
