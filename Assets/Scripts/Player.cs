using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [SerializeField]
    float runSpeed = 5f;

    Rigidbody2D rigidBody;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Run();
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
}
