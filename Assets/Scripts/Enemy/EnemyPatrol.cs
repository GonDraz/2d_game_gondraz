using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class EnemyPatrol : MonoBehaviour
{
    #region Variables
    [Header("Speed Settings")]
    [SerializeField] private float moveSpeed;

    private Rigidbody2D rb;
    private Animator animator;

    #endregion

    #region MonoBehaviour Callbacks
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
    }


    private void FixedUpdate()
    {
        if (IsFacingRight())
        {
            rb.velocity = new Vector2(moveSpeed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed,0);
        }
    }
    #endregion

    #region Private Methor
    private bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(rb.velocity.x)), transform.localScale.y);
    }

    #endregion
}




