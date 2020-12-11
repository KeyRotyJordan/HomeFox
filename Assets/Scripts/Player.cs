using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;
    private BoxCollider2D boxCollider2D;
    private Rigidbody2D rigidBody2D;
    public Slider sliderHealth;
    public Slider sliderGems;
    public AudioSource jumpAudio;
    public ParticleSystem confettis;

    private bool facingRight = true;
    public int health = 100;
    public int gems = 0;

    // Start is called before the first frame update
    private void Start()
    {
        health = 100;
        gems = 0;
        sliderHealth.value = health;
        sliderGems.value = gems;
        jumpAudio.Stop();
    }

    private void Awake()
    {
        rigidBody2D = transform.GetComponent<Rigidbody2D>();
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            float jumpVelocity = 8f;
            rigidBody2D.velocity = Vector2.up * jumpVelocity;
            jumpAudio.Play();
        }
    }

    private void FixedUpdate()
    {
        float moveSpeed = 5f;
        rigidBody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        if (Input.GetKey(KeyCode.A))
        {
            rigidBody2D.velocity = new Vector2(-moveSpeed, rigidBody2D.velocity.y);
            Flip(false);
            facingRight = false;
        }
        else
        {
            if (Input.GetKey(KeyCode.D))
            {
                rigidBody2D.velocity = new Vector2(+moveSpeed, rigidBody2D.velocity.y);
                Flip(true);
                facingRight = true;
            }
            else
            {
                rigidBody2D.velocity = new Vector2(0, rigidBody2D.velocity.y);
                rigidBody2D.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }

    private bool isGrounded()
    {
        float extraHeightText = 1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, extraHeightText, platformLayerMask);
        return raycastHit.collider != null;
    }


    private void Flip(bool direction)
    {
        if (facingRight != direction)
            transform.Rotate(0f, 180f, 0f);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        sliderHealth.value = health;
        if (health <= 0)
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        transform.position = new Vector3(-8f, -2f, 0f);
        health = 100;
        sliderHealth.value = health;
    }

    public void Win()
    {
        rigidBody2D.constraints = RigidbodyConstraints2D.FreezeAll;
        confettis.Play();
    }
}