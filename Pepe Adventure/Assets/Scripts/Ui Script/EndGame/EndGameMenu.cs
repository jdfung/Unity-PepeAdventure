using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameMenu : MonoBehaviour
{
    [SerializeField] public GameObject EndGameUI;
    [SerializeField] private AudioSource FoundScrollSound;
    private bool isOnChest = false;
    

    private void Update()
    {
        if (isOnChest && Input.GetKeyDown(KeyCode.LeftShift))
        {
            FoundScrollSound.Play();
            EndGameUI.SetActive(true);
        }

        if(!isOnChest)
        {
            EndGameUI.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            Debug.Log("Trigger Chest");
            isOnChest = true;
        }
    }

    private void OnTriggerExit2D(Collider2D trapchest)
    {
        if (trapchest.transform.tag == "Player")
        {
            isOnChest = false;
        }
    }

    public void yes()
    {
        SceneManager.LoadScene("EndCredit");
    }
}
