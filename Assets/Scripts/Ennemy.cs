using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;

    public float moveSpeed = 1f;
    public float distance = 1f;

    public Vector2 direction = Vector2.down;
    public Transform flipDetect;

    public int health = 0;
    public int damage = 0;

    private bool facingRight = false;

    // Update is called once per frame
    void Update()
    {
        Vector2 position = flipDetect.position;
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        RaycastHit2D raycastHit = Physics2D.Raycast(position, direction, distance, platformLayerMask);
        if (direction == Vector2.down)
        {
            if (raycastHit.collider == null)
            {
                if (facingRight == true)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    facingRight = false;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 180, 0);
                    facingRight = true;
                }
            }
        }
        else if (direction == Vector2.left)
        {
            if (raycastHit.collider != null)
            {
                if (facingRight == true)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    facingRight = false;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 180, 0);
                    facingRight = true;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(damage);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
