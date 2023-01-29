using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    private GameObject currentTeleporter;
    [SerializeField] private AudioSource TeleportSoundEffect;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (currentTeleporter != null)
            {
                transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;
                anim.SetTrigger("Teleport");
                TeleportSoundEffect.Play();
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Teleporter"))
        {
            currentTeleporter = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Teleporter"))
        {
            if(other.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
            }
        }
    }

}
