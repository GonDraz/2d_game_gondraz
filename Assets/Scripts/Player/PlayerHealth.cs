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
    public int currentHealth;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();    
        currentHealth = maxHealth;
        UpdateSlider();
    }

    public void TakeDamage(int Damage)
    {
        AudioManager.Instance.PlaySFX("Hit");

        currentHealth -= Damage;
        if (currentHealth <= 0)
        {
            GameController.GameOver();
        }
        UpdateSlider();
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
