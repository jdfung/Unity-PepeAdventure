using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    [SerializeField] private Character playableCharacter;
    [SerializeField] private Transform spawnPosition;

    public GameObject DeathMenuUI;
    bool levelRestarted = false;

    IEnumerator waitDeath()
    {
        yield return new WaitForSeconds(0.5f);
        actDeathUI();
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (playableCharacter.GetComponent<Health>().CurrentHealth <= 0)
        {
            StartCoroutine(waitDeath());
        }

        if (levelRestarted)
        {
            StopAllCoroutines();
            playableCharacter.GetComponent<Health>().Revive();
            Time.timeScale = 1f;
            DeathMenuUI.SetActive(false);
            playableCharacter.transform.position = spawnPosition.position;
            levelRestarted = false;
           
        }
    }

    void actDeathUI()
    {
        DeathMenuUI.SetActive(true);
    }

    public void Restart()
    {
        levelRestarted = true;

    }

    public void backToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
}
    