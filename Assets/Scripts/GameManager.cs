using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.UI;
public class GameManager : MonoBehaviour
{
    [Header("Hud Text")]
    public TextMeshProUGUI waveCounter;
    public TextMeshProUGUI liveCounter;
    public TextMeshProUGUI scoreCounter;

    [Header("Ints")]
    public int score;
    public int lives;
    public int maxLives;
    public int waves;

    [Header("Scripts")]
    public PlayerController playerController;
    public SpawnManager sm;

    // Start is called before the first frame update
    void Start()
    {
        //starting the everything at default values
        score = 0;
        lives = 5;
        waves = 1;

        //getting the gameObjects and components
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        sm = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        //Starting the game at wave 1
        UpdateWave();
    }

    //Updating the score
    void UpdateScore()
    {
        scoreCounter.text = $"Score: {score}";  
    }
    public void AddScore(int amountToAdd)
    {
        score += amountToAdd;
        UpdateScore();
    }

    //updating the lives 
    public void UpdateLives()
    {
        liveCounter.text = $"Lives: {lives}";
    }

    public void LooseLife()
    {
        lives --;
        UpdateLives();
    }

    //updating the waves 
    public void UpdateWave()
    {
        waveCounter.text = $"Wave: {waves}";
    }
    public void AddWave()
    {
        waves++;
        UpdateWave();
    }
}
