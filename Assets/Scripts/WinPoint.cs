using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPoint : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col2)
    {
        if (col2.tag == "Player")
        {
            GameController.Instance.GameWin();
        }
    }
}
