using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float speed = 1f;

    Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.velocity = new Vector2(speed, 0);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, 1);
        speed *= -1;
    }
}
