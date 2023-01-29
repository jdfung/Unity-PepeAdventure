using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Deaths : MonoBehaviour
{
    [SerializeField] private Character playableCharacter;
    public TextMeshProUGUI deathText;
    

    void Start()
    {
        deathText.color = Color.white;
        playableCharacter.GetComponent<Health>().resetDeathCount();
    }

    // Update is called once per frame
    void Update()
    {
        
        string deaths = ((int)playableCharacter.GetComponent<Health>().deathCount).ToString();
        deathText.text = "Not more than 2 deaths: " + deaths + "/" + "2";

        if (playableCharacter.GetComponent<Health>().deathCount > 2)
        {
            deathText.color = Color.red;
        }
    }
}
