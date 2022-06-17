using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D  rb;
    float MoveSpeed = 5f;

    Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal"); // GetAxis makes the player accelerate and deccelerate
        movement.y = Input.GetAxisRaw("Vertical"); // Whereas GetAxisRaw doesn't
        rb.MovePosition(rb.position + movement * MoveSpeed * Time.fixedDeltaTime);
    }

    void FixedUpdate()
    {

    }
}
