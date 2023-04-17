using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MosuePosition : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        var mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseposition.z = 0;
        transform.position = Vector3.Lerp(transform.position, mouseposition,0.1f);       
    }
}
