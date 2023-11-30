using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fliying : MonoBehaviour
{
    [SerializeField] private float velocity;
    [SerializeField] private Transform[] wayPoints;
    [SerializeField] private float minDIstance;

    private int randomNumber;
    private SpriteRenderer spriteR;

    private void Start()
    {
        randomNumber = Random.Range(0, wayPoints.Length);
        spriteR = GetComponent<SpriteRenderer>();
        Rotate();
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, wayPoints[randomNumber].position, velocity * Time.deltaTime);
        if (Vector2.Distance(transform.position, wayPoints[randomNumber].position)< minDIstance)
        {
            randomNumber = Random.Range(0, wayPoints.Length);
            Rotate();
        }
    }
    private void Rotate()
    {
        if (transform.position.x < wayPoints[randomNumber].position.x)
        {
            spriteR.flipX = true;
        }else
        {
            spriteR.flipX = false;
        }
    }
}
