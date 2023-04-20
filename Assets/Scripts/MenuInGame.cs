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
    }

    [System.Obsolete]
    public void ToggleMenuInGame()
    {
        if (menu != null)
        {
            bool ckeck = menu.active;
            button.SetActive(ckeck);
            menu.SetActive(!ckeck);
        }
    }

    public void BackToMenuScreen()
    {
        SceneManager.LoadScene("Menu");
    }
}
