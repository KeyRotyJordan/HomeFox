using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 5f;
    public AudioSource shotAudio;

    private void Start()
    {
        shotAudio.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        shotAudio.Play();
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
