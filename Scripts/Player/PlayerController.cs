using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private Vector2 orientation;
    public float movementSpeed;
    private float horizontalAxis;
    private float verticalAxis;
    public bool velocity;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        movementSpeed = 1f;
        orientation = new Vector2(1, 0);
    }
    
    private void Update() {
        if (GetComponent<PlayerLife>().GetPlayerAlive()) {
            float horizontalAxis = Input.GetAxisRaw("Horizontal");
            float verticalAxis = Input.GetAxisRaw("Vertical");

            if (horizontalAxis == 0) {
                animator.SetBool("movingLeft", false);
                animator.SetBool("movingRight", false);
            } else if (horizontalAxis < 0) {
                animator.SetBool("movingLeft", true);
                animator.SetBool("movingRight", false);
            } else {
                animator.SetBool("movingLeft", false);
                animator.SetBool("movingRight", true);
            }

            if (verticalAxis == 0) {
                animator.SetBool("movingUp", false);
                animator.SetBool("movingDown", false);
            } else if (verticalAxis < 0) {
                animator.SetBool("movingUp", false);
                animator.SetBool("movingDown", true);
            } else {
                animator.SetBool("movingUp", true);
                animator.SetBool("movingDown", false);
            }

            if (Input.GetKey(KeyCode.LeftShift)) {
                movementSpeed = 3f;
            } else {
                movementSpeed = 1f;
            }

            rigidBody.velocity = new Vector2(horizontalAxis, verticalAxis) * movementSpeed;

            if (horizontalAxis == 0 && verticalAxis == 0) {
                velocity = false;
            } else {
                orientation = new Vector2(horizontalAxis, verticalAxis);
                velocity = true;
            }
        } else {
            rigidBody.velocity = new Vector2(0, 0);
        }
    }

    public Vector2 GetOrientation()
    {
        return orientation;
    }

    public bool GetVelocity()
    {
        return velocity;
    }
}