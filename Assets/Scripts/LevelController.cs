using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class LevelController : MonoBehaviour
{
    public string level;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Start"))
        {
            SceneManager.LoadScene(level);
        } 
        if(Input.GetButtonDown("Quit"))
        {
            Application.Quit();
            Debug.Log("It worked!");
        }
    }
}