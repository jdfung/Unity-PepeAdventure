using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndToMenu : MonoBehaviour
{
    public void backToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
