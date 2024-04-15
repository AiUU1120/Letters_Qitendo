using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float xInput;
    [SerializeField]
    private float speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        CheckInput();
    }

    private void FixedUpdate()
    {
        GroundMovement();
    }

    void CheckInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");
    }

    void GroundMovement()
    {
        rb.velocity = new Vector2(xInput * speed, rb.velocity.y);
    }
}
