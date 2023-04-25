using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject main;
    [SerializeField] private GameObject setting;
    [SerializeField] private GameObject audioMenu;
    [SerializeField] private GameObject language;


    private void Start()
    {
        main.SetActive(true);
        setting.SetActive(false);
        audioMenu.SetActive(false);
        language.SetActive(false);
    }
    public void PlayButton()
    {
        AudioManager.Instance.PlaySFX("Button");
        Loader.Instance.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitButton()
    {
        AudioManager.Instance.PlaySFX("Button");
        Application.Quit();
    }

    public void SettingButton()
    {
        AudioManager.Instance.PlaySFX("Button");
        main.SetActive(false);
        setting.SetActive(true);
    }

    public void BackMenuButton()
    {
        AudioManager.Instance.PlaySFX("Button");
        main.SetActive(true);
        setting.SetActive(false);
    }

    public void BackSettingButton()
    {
        AudioManager.Instance.PlaySFX("Button");
        setting.SetActive(true);
        audioMenu.SetActive(false);
        language.SetActive(false);
    }

    public void AudioButton()
    {
        AudioManager.Instance.PlaySFX("Button");
        setting.SetActive(false);
        audioMenu.SetActive(true);
    }
    public void LanguageButton()
    {
        AudioManager.Instance.PlaySFX("Button");
        setting.SetActive(false);
        language.SetActive(true);
    }
}
