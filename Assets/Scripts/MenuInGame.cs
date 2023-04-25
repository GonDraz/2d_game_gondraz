using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInGame : MonoBehaviour
{
    #region Variables
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject button;
    #endregion

    #region MonoBehaviour Callbacks
    private void Start()
    {
        menu.SetActive(false);
        button.SetActive(true);
        GameController.Instance.pasueSystem = false;

    }

    #endregion

    #region Public Methor
    [System.Obsolete]
    public void ToggleMenuInGame()
    {
        if (menu != null)
        {
            bool check = menu.active;
            button.SetActive(check);
            menu.SetActive(!check);

            AudioManager.Instance.PlaySFX("Button");
            GameController.Instance.pasueSystem = !check;
        }
    }

    public void BackToMenuScreen()
    {
        AudioManager.Instance.PlaySFX("Button");
        Loader.Instance.LoadScene(0);

    }


    public void RestartScreen()
    {
        AudioManager.Instance.PlaySFX("Button");
        Loader.Instance.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    #endregion
}
