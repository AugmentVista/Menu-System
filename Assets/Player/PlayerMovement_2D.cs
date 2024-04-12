using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_2D : MonoBehaviour
{
    [Header("Input settings:")]
    public float speedMultiplier = 5.0f;

    [Space]
    [Header("Character Stats:")]
    public Vector2 movementDirection;
    public float movementSpeed;

    [Space]
    [Header("References:")]
    public Rigidbody2D rb;
    public Animator animator;

    private Vector2 lastMovementDirection;
    private bool Walking;
    private bool Standing;
    //private bool Running;
    private bool Dancing;
    private float TimeSpentIdle;
    public float IdleThreshold;


    private void Start()
    {
        TimeSpentIdle = Time.time;
    }

    private void Update()
    {
        if (ReferenceManager.dialogueManagerDependant.isInDialogue)
        {
            movementSpeed = 0;
            UpdateAnimator();
            rb.Sleep();
            return;
        }

        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);
        movementDirection.Normalize();
        Move();
        UpdateAnimator();
    }
    private void Move()
    {
        rb.velocity = movementDirection * movementSpeed * speedMultiplier;
    }
    private void UpdateAnimator() // Set parameters for blend tree
    {
        if (Input.anyKeyDown)
        {
            // Update the last input time to the current time
            TimeSpentIdle = Time.time;
        }

        animator.SetFloat("Horizontal movement", movementDirection.x);
        animator.SetFloat("Vertical movement", movementDirection.y);
        animator.SetFloat("Speed", movementSpeed);

        if (movementDirection != Vector2.zero)
        {
            lastMovementDirection = movementDirection;
        }

        if (movementSpeed < 0.1f)  // Set the last direction if the player is not currently moving
        {
            animator.SetFloat("Horizontal movement", lastMovementDirection.x);
            animator.SetFloat("Vertical movement", lastMovementDirection.y);
            if (Time.time - TimeSpentIdle >= IdleThreshold) 
            {
                Dancing = true;
                animator.SetBool("Dancing", Dancing);
                //Debug.Log(lastMovementDirection.y.ToString());
                //Debug.Log(lastMovementDirection.x.ToString());

            }
            else if (Time.time - TimeSpentIdle >= IdleThreshold)
            {
                Dancing = false;
                animator.SetBool("Dancing", Dancing);
            }
        }
    }

    private bool AmIMoving()
    {
        if (movementSpeed < 0.01f)
        {
            Standing = true;
            return false;
        }
        else
        {
            Standing = false;
            return true;
        }
    }
}