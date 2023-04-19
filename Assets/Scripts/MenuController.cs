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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void SettingButton()
    {
        main.SetActive(false);
        setting.SetActive(true);
    }

    public void BackMenuButton()
    {
        main.SetActive(true);
        setting.SetActive(false);
    }

    public void BackSettingButton()
    {
        setting.SetActive(true);
        audioMenu.SetActive(false);
        language.SetActive(false);
    }

    public void AudioButton()
    {
        setting.SetActive(false);
        audioMenu.SetActive(true);
    }
    public void LanguageButton()
    {
        setting.SetActive(false);
        language.SetActive(true);

    }
}
