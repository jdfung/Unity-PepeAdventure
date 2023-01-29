using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dash : MonoBehaviour
{
    public TextMeshProUGUI DashText;
    int dash = 0;

    void Start()
    {
        DashText.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            dash += 1;
        }
        string dashNum = ((int)dash).ToString();
        DashText.text = "Dash not more than 10 times: " + dashNum + "/10";

        if(dash > 10)
        {
            DashText.color = Color.red;
        }
    }
}
