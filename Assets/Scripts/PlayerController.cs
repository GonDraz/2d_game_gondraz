using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    Vector2 movement;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
        animator.SetFloat("speed", Mathf.Abs(movement.x));
    }
    public void Jump(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        rb.rotation = 0f;
        rb.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);
    }
}
