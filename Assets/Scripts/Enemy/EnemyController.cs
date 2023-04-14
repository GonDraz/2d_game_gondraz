using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col2)
    {
        print(gameObject.name + " OnTriggerEnter2D voi " + col2.gameObject.name);
    }
}
