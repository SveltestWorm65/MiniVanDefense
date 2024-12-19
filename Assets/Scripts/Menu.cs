using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    public void OnPlayButton(string level)
    {
        SceneManager.LoadScene(level);

        if (Input.GetButtonDown("Start"))
        {
            SceneManager.LoadScene("MainLevel");
        }
    }
    public void OnApplicationQuit()
    {
        Application.Quit();
    }
   
}
