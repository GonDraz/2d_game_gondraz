using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject gameWinMenu;

    public bool pasueSystem = false;

    private void Start()
    {
        if (gameOverMenu != null)
        {
            gameOverMenu.SetActive(false);
        }
        if (gameWinMenu != null)
        {
            gameWinMenu.SetActive(false);
        }
    }
    void Awake()
    {
        Instance = this;
    }

    public void GameOver()
    {
        pasueSystem = true;
        if (gameOverMenu != null)
        {
            AudioManager.Instance.PlaySFX("Over");
            gameOverMenu.SetActive(true);
        }
    }

    public void GameWin()
    {
        pasueSystem = true;
        if (gameWinMenu != null)
        {
            AudioManager.Instance.PlaySFX("Win");
            gameWinMenu.SetActive(true);
        }
    }
}
