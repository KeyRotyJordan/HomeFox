using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        // Suis le joueur
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }
}
