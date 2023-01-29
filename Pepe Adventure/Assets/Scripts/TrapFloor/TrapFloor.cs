using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapFloor : MonoBehaviour
{
    private float nextActionTime = 0.0f;
    public float period = 0.1f;
    public GameObject Trapfloor;
    public GameObject TrapLava;
    bool playerIsOn = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerIsOn = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerIsOn = false;
        }
    }

    public void Update()
    {

        if (Time.time > nextActionTime)
        {
            nextActionTime = Time.time + period; 

            if (playerIsOn)
            {
                Trapfloor.SetActive(false);
                TrapLava.SetActive(true);

            }

            else if (!playerIsOn)
            {
                Trapfloor.SetActive(true);
                TrapLava.SetActive(false);
            }
        }
    }
}
