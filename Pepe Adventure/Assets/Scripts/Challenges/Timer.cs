using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float startTime;
    

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        timerText.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        timerText.text = "Complete within 5 minutes: " + minutes + ":" + seconds;

        if(t/60 >= 5)
        {
            timerText.color = Color.red;
        }
    } 

}
