using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] public GameObject currentLevel;
    [SerializeField] public GameObject nextLevel;
    [SerializeField] public GameObject LevelTransition;
    private Animator anim;

    bool playerIsON = false;

    void Start()
    {
        anim = LevelTransition.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerIsON = true;

                
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerIsON = false;
        }

    }

    IEnumerator wait()
    {
        anim.SetTrigger("TransEnd");
        yield return new WaitForSeconds(0.89f);
        currentLevel.SetActive(false);
        Player.transform.position = spawnPosition.position;
        nextLevel.SetActive(true);
    }

    private void Update()
    {
        if(playerIsON && Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(wait());
        }
    }
}
