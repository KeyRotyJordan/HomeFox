using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherries : MonoBehaviour
{
    public int healthBack = 100;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            if (player.health < 100)
            {
                player.health = healthBack;
                player.sliderHealth.value = player.health;
                Destroy(gameObject);
            }
        }
    }
}
