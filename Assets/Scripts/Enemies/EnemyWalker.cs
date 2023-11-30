using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalker : MonoBehaviour
{
    private SpriteRenderer spriteR;
    private float health;
    private Animator enemyAnim;

    private void Start()
    {
        spriteR = GetComponent<SpriteRenderer>();
        enemyAnim = GetComponent<Animator>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Attack();
        }else
        {
            enemyAnim.SetBool("Attacking", false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        enemyAnim.SetBool("Attacking", false);
    }
    private void Attack()
    {
        enemyAnim.SetBool("Attacking", true);

    }
}
