using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDamage : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private GameObject dieEffect;
    [SerializeField] private float maxHealth;

    private SpriteRenderer spriteR;
    private float health;

    private void Start()
    {
        health = maxHealth;
        healthBar.UpdateHealthBar(maxHealth, health);
        spriteR = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            StartCoroutine(GetDamage1());
        }
    }
    private void OnMouseDown()
    {
        StartCoroutine(GetDamage1());
    }
    IEnumerator GetDamage1()
    {
        float damageDuration = 0.1f;
        float damage = 1;
        health -= damage;
        healthBar.UpdateHealthBar(maxHealth, health);

        if (health > 0)
        {
            spriteR.color = Color.red;
            yield return new WaitForSeconds(damageDuration);
            spriteR.color = Color.white;
        }
        else
        {
            Instantiate(dieEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
