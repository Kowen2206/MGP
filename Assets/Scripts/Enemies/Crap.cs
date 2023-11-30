using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crap : MonoBehaviour
{
    [SerializeField] private float velocity;
    [SerializeField] private Transform groundC;
    [SerializeField] private float distance;
    [SerializeField] private bool rightMove;
    [SerializeField] private LayerMask Ground;

    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        RaycastHit2D infor = Physics2D.Raycast(groundC.position, Vector2.down, distance, Ground);
        rb.velocity = new Vector2(velocity, rb.velocity.y);

        if (infor == false)
        {
            Rotate();
        }
    }
    private void Rotate()
    {
        rightMove = !rightMove;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        velocity *= -1;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundC.transform.position, groundC.transform.position + Vector3.down * distance);
    }
}
