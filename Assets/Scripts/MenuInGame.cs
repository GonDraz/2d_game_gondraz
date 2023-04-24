using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInGame : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject button;


    private void Start()
    {
        menu.SetActive(false);
        button.SetActive(true);
        GameController.Instance.pasueSystem = false;

    }

    [System.Obsolete]
    public void ToggleMenuInGame()
    {
        if (menu != null)
        {
            bool ckeck = menu.active;
            button.SetActive(ckeck);
            menu.SetActive(!ckeck);

            AudioManager.Instance.PlaySFX("Button");
            GameController.Instance.pasueSystem = !ckeck;
        }
    }

    public void BackToMenuScreen()
    {
        AudioManager.Instance.PlaySFX("Button");
        SceneManager.LoadScene("Menu");
    }


    public void RestartScreen()
    {
        AudioManager.Instance.PlaySFX("Button");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
