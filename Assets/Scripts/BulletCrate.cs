using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCrate : MonoBehaviour
{
    public Rigidbody2D rigidbody;

    public float speed = 20f;
    public int damage = 15;

    private void Start()
    {
        rigidbody = transform.GetComponent<Rigidbody2D>();
        rigidbody.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Ennemy ennemy = collision.GetComponent<Ennemy>();
        if (ennemy != null)
        {
            ennemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
