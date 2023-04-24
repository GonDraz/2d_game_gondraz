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

    public bool pasueSystem = false;

    private void Start()
    {
        if (gameOverMenu != null)
        {
            gameOverMenu.SetActive(false);
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
        AudioManager.Instance.PlaySFX("Win");

    }
}
