using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [SerializeField]
    float runSpeed = 8f;

    Rigidbody2D rigidBody;

    Animator animator;

    Collider2D collide;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        collide = GetComponent<Collider2D>();
    }

    void Update()
    {
        Run();

        if (CrossPlatformInputManager.GetButtonDown("Jump") && collide.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            Jump();
        }
    }

    private void Run()
    {
        rigidBody.velocity = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal") * runSpeed, rigidBody.velocity.y);
        bool isRunning = Mathf.Abs(rigidBody.velocity.x) > Mathf.Epsilon;
        animator.SetBool("IsRunning", isRunning);

        if (isRunning)
        {
            transform.localScale = new Vector2(Mathf.Sign(rigidBody.velocity.x), 1);
        }
    }

    private void Jump()
    {
        rigidBody.velocity += new Vector2(0, 28);
    }
}
