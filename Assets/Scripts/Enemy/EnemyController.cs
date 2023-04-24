using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private bool checkDeleteObject = true;

    [System.Obsolete]
    void OnTriggerEnter2D(Collider2D col2)
    {
        if (col2.tag == "Player")
        {
            var healthComponanet = col2.GetComponent<PlayerHealth>();
            if (healthComponanet != null)
            {
                if (healthComponanet.immortal.active == false)
                {
                    healthComponanet.TakeDamage(damage);

                    if (checkDeleteObject)
                    {
                        Destroy(this.gameObject);
                    }
                }
            }
        }
    }
}
