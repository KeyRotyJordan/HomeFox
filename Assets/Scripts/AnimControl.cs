using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControl : MonoBehaviour
{
    public bool isActive = true;
    public GameObject crankup;

    // Update is called once per frame
    void Update()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if (Input.GetButtonDown("Action") && isActive && player.sliderGems.value >= 10)
        {
            crankup.GetComponent<Animator>().Play("Crankup");
            isActive = false;
            GameObject doorObject = GameObject.FindGameObjectWithTag("Door");
            doorObject.transform.position = new Vector3(22.5f, -7f, -1f);
        }
        if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
        {
            player.GetComponent<Animator>().enabled = true;
            player.GetComponent<Animator>().Play("Player");
        }
        if(Input.GetButtonUp("Horizontal") || Input.GetButtonUp("Vertical"))
        {
            player.GetComponent<Animator>().enabled = false;
        }
    }
}
