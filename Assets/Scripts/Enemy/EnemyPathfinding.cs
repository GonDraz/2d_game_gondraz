using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPathfinding : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private float vision;
    NavMeshAgent agent;
    private Animator animator;

    private bool isFacingRight = true;
    private Transform defaultTransfrom;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
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

        if (Mathf.Abs(transform.position.x - target.position.x) < vision)
        {
            agent.SetDestination(target.position);
        }

        animator.SetBool("isGround", IsGrounded());


    }
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

}

