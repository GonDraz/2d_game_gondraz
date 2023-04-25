using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPathfinding : MonoBehaviour
{
    #region Variables
    [Header("Ground")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [Header("Settings")]
    [SerializeField] private float vision;
    [SerializeField] private float speed;

    NavMeshAgent agent;
    private Animator animator;
    private bool isFacingRight = true;

    private Transform target;
    #endregion

    #region MonoBehaviour Callbacks
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        target = FindObjectOfType<PlayerMovement>().transform;
    }

    void Update()
    {
        if (!isFacingRight && transform.position.x - target.position.x > 0f)
        {
            Flip();
        }
        else if (isFacingRight && transform.position.x - target.position.x < 0f)
        {
            Flip();
        }

        if (!GameController.Instance.pasueSystem && (Mathf.Abs(transform.position.x - target.position.x) < vision))
        {
            agent.speed = speed;
        }
        else
        {
            agent.speed = 0f;
        }
        agent.SetDestination(target.position);
        animator.SetBool("isGround", IsGrounded());
    }
    #endregion

    #region Private Methor
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector2 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.5f, groundLayer);
    }
    #endregion
}

