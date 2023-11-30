using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Floats")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float rayLineSize;
    [SerializeField] private float speedBall;

    //Dependences----------------------------------
    private Rigidbody2D rb;
    private Animator playerAnim;
    private float velx, vely;
    private bool inGround;
    Vector3 targetRotation;
    Vector3 finalTarget;

    [Header("Detectors")]
    [SerializeField] private Transform rayGenerate;
    [SerializeField] private Transform gunCanon;
    [SerializeField] private SpriteRenderer gunSR;

    [Header("Layers")]
    [SerializeField] private LayerMask ground;

    [Header("Bools")]
    [SerializeField] private bool doubleJump;

    [Header("GameObjects")]
    [SerializeField] private GameObject ball;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        inGround = Physics2D.Raycast(rayGenerate.position, Vector2.down, rayLineSize, ground);
    }
    private void FixedUpdate()
    {
        Direction();
        Move();
        Jump();
    }
    private void Move()
    {
        velx = Input.GetAxisRaw("Horizontal");
        vely = rb.velocity.y;

        rb.velocity = new Vector2(velx * speed, vely);
    }
    private void Jump()
    {
        if (Input.GetButton("Jump") && inGround)
        {
            
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    private void Direction()
    {
        if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(rayGenerate.transform.position, rayGenerate.transform.position + Vector3.down * rayLineSize);
    }
}
