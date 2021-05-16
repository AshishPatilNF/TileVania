using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;

    Rigidbody2D rigidBody;

    Animator animator;

    BoxCollider2D boxFeetCollider;

    CapsuleCollider2D capsuleBodyCollider;

    bool isAlive = true;

    float gravityAtStart;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        boxFeetCollider = GetComponent<BoxCollider2D>();
        capsuleBodyCollider = GetComponent<CapsuleCollider2D>();
        gravityAtStart = rigidBody.gravityScale;
    }

    void Update()
    {
        if(capsuleBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Obstacles")))
        {
            isAlive = false;
            animator.SetTrigger("Death");
            rigidBody.velocity = new Vector2(0, 50);
        }

        if(isAlive)
        {
            Run();

            if (CrossPlatformInputManager.GetButtonDown("Jump") && boxFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
                Jump();

            Climb();
        }
    }

    private void Run()
    {
        rigidBody.velocity = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal") * speed, rigidBody.velocity.y);
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

    private void Climb()
    {
        if(!boxFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
            rigidBody.gravityScale = gravityAtStart;
            animator.SetBool("IsClimbing", false);
            return;
        }

        rigidBody.gravityScale = 0;
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, CrossPlatformInputManager.GetAxis("Vertical") * speed);
        animator.SetBool("IsClimbing", Mathf.Abs(rigidBody.velocity.y) > Mathf.Epsilon);
    }
}
