using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public void OnPlayButton(string level)
    {
        if (Input.GetButtonDown("Shoot") || Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(level);
        }
    }
    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
