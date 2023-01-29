using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeIntro : MonoBehaviour
{
    public GameObject ChallengeBox;
    public GameObject SideChallengeBox;

    IEnumerator waitChallenge()
    {
        yield return new WaitForSeconds(0.89f);
        Time.timeScale = 0f;
        ChallengeBox.SetActive(true);
    }

    void Start()
    {
        StartCoroutine(waitChallenge());
        
    }

    public void continuePress()
    {
        Time.timeScale = 1f;
        ChallengeBox.SetActive(false);
        SideChallengeBox.SetActive(true);
    }

}
