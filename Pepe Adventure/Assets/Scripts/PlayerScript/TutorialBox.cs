using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBox : MonoBehaviour
{
    bool playerIsOn = false;
    public GameObject trigger;
    public GameObject dialogueBox;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            playerIsOn = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
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

    // Update is called once per frame
    void Update()
    {
        if(playerIsOn)
        {
            dialogueBox.SetActive(true);
        }

        else
        {
            dialogueBox.SetActive(false);
        }
    }
}
