using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    #region Variables

    [Header("Base Settings")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform headerCheck;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform leftCheck;
    [SerializeField] private Transform rightCheck;

    [SerializeField] private LayerMask groundLayer;


    [Header("Speed Settings")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpingPower;


    private Vector2 movement;

    private Animator animator;
    private bool isFacingRight = true;

    private bool isJumping = false;

    #endregion

    #region MonoBehaviour Callbacks
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!GameController.Instance.pasueSystem)
        {
            if (!isFacingRight && movement.x > 0f)
            {
                Flip();
            }
            else if (isFacingRight && movement.x < 0f)
            {
                Flip();
            }

            if (!IsLeftRight())
            {
                animator.SetFloat("xVelocity", 0f);
            }
            else
            {
                animator.SetFloat("xVelocity", Mathf.Abs(movement.x));
            }

            animator.SetFloat("yVelocity", Mathf.Abs(movement.y));

            isJumping = !IsGrounded();
            animator.SetBool("isJumping", isJumping);
        }
    }

    private void FixedUpdate()
    {

        if (!GameController.Instance.pasueSystem)
        {

            if (!IsLeftRight() && !IsGrounded())
            {
                rb.velocity = new Vector3(0, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector3(movement.x * moveSpeed, rb.velocity.y);
            }
        }
    }
    #endregion

    #region InputSystem Callbacks

    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (!GameController.Instance.pasueSystem)
        {
            if (context.performed && IsGrounded() && !IsHearded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                isJumping = true;
            }
            if (context.canceled && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }
        }
    }
    #endregion

    #region Private Methor
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    private bool IsHearded()
    {
        return Physics2D.OverlapCircle(headerCheck.position, 0.2f, groundLayer);
    }
    private bool IsLeftRight()
    {
        bool isleft = Physics2D.OverlapCircle(leftCheck.position, 0.4f, groundLayer);
        bool isRight = Physics2D.OverlapCircle(rightCheck.position, 0.4f, groundLayer);

        return (isleft || isRight) ? false : true;
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector2 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
    #endregion
}
