using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    [SerializeField] private int health;
    void OnTriggerEnter2D(Collider2D col2)
    {
        if (col2.tag == "Player")
        {
            var healthComponanet = col2.GetComponent<PlayerHealth>();
            if (healthComponanet != null)
            {
                if(healthComponanet.currentHealth != healthComponanet.maxHealth)
                {

                    healthComponanet.TakeHeal(health);
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
