using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public static Loader Instance { get; private set; }

    [SerializeField] private Animator animator;

    [SerializeField] private float transitionTime = 1f;

    void Awake()
    {
        Instance = this;
    }

    public void LoadScene(int scene)
    {
        StartCoroutine(Load(scene));
    }
    IEnumerator Load(int scene)
    {
        animator.SetTrigger("Start");
        AudioManager.Instance.PlaySFX("Wipe");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(scene);
    }
}
