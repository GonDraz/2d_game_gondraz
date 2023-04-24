using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public int maxHealth;
    [SerializeField] private Slider slider;
    [SerializeField] private Gradient gradient;
    [SerializeField] private Image fill;
    [SerializeField] private float immortalTime;
    public GameObject immortal;

    public int currentHealth;
    private float timeRemaining = 0;

    private Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        UpdateSlider();
        immortal.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.fixedDeltaTime;
            immortal.SetActive(true);
        }
        else {
            immortal.SetActive(false);
        }
    }

    public void TakeDamage(int Damage)
    {
        if (timeRemaining <= 0)
        {
            timeRemaining = immortalTime;

            AudioManager.Instance.PlaySFX("Hit");

            currentHealth -= Damage;
            if (currentHealth <= 0)
            {
                GameController.Instance.GameOver();
            }
            UpdateSlider();
        }
    }
    public void TakeHeal(int Heal)
    {
        currentHealth += Heal;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UpdateSlider();
    }

    private void UpdateSlider()
    {
        float health = (float)currentHealth / (float)maxHealth;
        slider.value = health;
        fill.color = gradient.Evaluate(health);
    }
}
