using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    #region Variables
    [SerializeField] private int health;
    #endregion
    void OnTriggerEnter2D(Collider2D col2)
    {
        if (col2.tag == "Player")
        {
            var healthComponanet = col2.GetComponent<PlayerHealth>();
            if (healthComponanet != null)
            {
                if(healthComponanet.currentHealth != healthComponanet.maxHealth)
                {
                    AudioManager.Instance.PlaySFX("Heal");
                    healthComponanet.TakeHeal(health);
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
