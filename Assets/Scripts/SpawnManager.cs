using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Spawn Ranges")]
    public float xRange;
    public float yRange;
    public float zRange;

    [Header("Prefabs")]
    public GameObject[] enemyPrefab;

    [Header("Ints")]
    public int enemyCount;
    public int waveNumber = 1;

    [Header("GameManager")]
    public GameManager gm;

    [Header("Scripts")]
    public PlayerController playerController;
    public SmallEnemy smallEnemy;
    public BigEnemy bigEnemy;

    public float spawnRadius;
    void Start()
    {
        //finding gameobjects and their scripts
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        smallEnemy = GameObject.Find("AlienMidget").GetComponent<SmallEnemy>();
        bigEnemy = GameObject.Find("ChubbyAlien").GetComponent<BigEnemy>();

        //spawning the waves
        SpawnEnemyWave(waveNumber);

     

    }

    // Update is called once per frame
    public void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            gm.AddWave();
        }
       
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            int index = Random.Range(0, enemyPrefab.Length);

            Instantiate(enemyPrefab[index], RandomPos(), enemyPrefab[index].transform.rotation);
        }
    }
    public Vector3 RandomPos()
    {
        int index = Random.Range(0, enemyPrefab.Length);

        float xPos = Random.Range(-xRange, xRange);
        float yPos = Random.Range(-yRange, yRange);
        float zPos = Random.Range(-zRange, zRange);
        Vector3 RandomPosition = new Vector3(xPos, yPos, 8.95f);

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        bool needsToRespawn = true;
        
        while(needsToRespawn)
        {
            needsToRespawn = false;
            foreach(GameObject enemy in enemies)
            {
                if((RandomPosition - enemy.transform.position).magnitude < spawnRadius)
                {
                    xPos = Random.Range(-xRange, xRange);
                    yPos = Random.Range(-yRange, yRange);
                    zPos = Random.Range(-zRange, zRange);
                    RandomPosition = new Vector3(xPos, yPos, 8.95f);
                }
            }
        }

       /* while ((RandomPosition - enemyPrefab[index].transform.position).magnitude < safetyRadius)
        {
            xPos = Random.Range(-xRange, xRange);
            yPos = Random.Range(-yRange, yRange);
            zPos = Random.Range(-zRange, zRange);
            RandomPosition = new Vector3(xPos, yPos, zPos);
        }*/
        return RandomPosition;

       
    }
    public void SpawnPrefab()
    {
        int index = Random.Range(0, enemyPrefab.Length);

        Instantiate(enemyPrefab[index], RandomPos(), transform.rotation);
    }

    
}

