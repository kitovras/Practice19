using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement vars")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpOffset;
    [SerializeField] private float movementAcceleration;
    [SerializeField] private float maxBoost;

    [Header("Technical fields")]
    [SerializeField] private LayerMask ground;
    [SerializeField] private bool isGrounded;
    [SerializeField] private Transform groundColliderTransform;

    [SerializeField] AnimationCurve curve;
    [SerializeField] float movementSpeed;

    private Rigidbody2D rb;
    private AnimationStates animationStates;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animationStates = GetComponent<AnimationStates>();
    }
    private void FixedUpdate()
    {
        Vector3 overlapCirclePosition = groundColliderTransform.position;

        isGrounded = Physics2D.OverlapCircle(overlapCirclePosition, jumpOffset, ground);
    }

    public void Move(float direction, bool isJumpButtonPressed)
    {
        if(isJumpButtonPressed)
        {
            Jump();
        }
        if(Mathf.Abs(direction) > 0.000f)
        {
            HorizontalMovement(direction);
        }
    }

    private void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void HorizontalMovement(float direction)
    {
        var velocity = rb.velocity;
        //Vector2 currentSpeed = Vector2.MoveTowards(velocity, movementAcceleration * Vector2.right * direction, maxBoost);
        //var maxSpeedChange = maxBoost * Time.deltaTime;
        //velocity.x = Mathf.MoveTowards(velocity.x, currentSpeed.x, maxSpeedChange);
        //velocity.x = Mathf.MoveTowards(velocity.x, movementAcceleration, maxBoost);

        
        rb.velocity = new Vector2(curve.Evaluate(direction) * movementSpeed, rb.velocity.y);

        animationStates.FlipSprite(direction);
    }


}
