using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    [Header("Floats")]
    public float moveSpeed;

    [Header("Ints")]
    public int hp;

    [Header("Components")]
    public Rigidbody enemyRb;

    [Header("Scripts")]
    public GameManager gm;
    public PlayerController pc;

    [Header("Audio")]
    public AudioSource enemyAudio;
    public AudioClip killed;
    public AudioClip enemyDamaged;

    [Header("GameObjects")]
    public GameObject enemyProjectile;
    public GameObject projectileSpawner;
    public GameObject playerBorder2;
    // Start is called before the first frame update
    void Start()
    {
        //getting the enemies to spawn more like an interval and not like a wall
        transform.Translate(Vector3.forward * Random.Range(-5f, 0f));

        //getting the components
        enemyRb = GetComponent<Rigidbody>();
        enemyAudio = GetComponent<AudioSource>();

        //getting the gameObjects and Scripts
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        pc = GameObject.Find("Player").GetComponent<PlayerController>();

        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {


    }
    public IEnumerator Shoot()
    {
        Instantiate(enemyProjectile, projectileSpawner.transform.position, projectileSpawner.transform.rotation);
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(Shoot());
    }
    private void FixedUpdate()
    {
        //getting the enemies moving down
        enemyRb.AddForce(Vector3.forward * -moveSpeed, ForceMode.Acceleration);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            hp = hp - 1;
            enemyAudio.PlayOneShot(enemyDamaged);
            Destroy(other.gameObject);
            if (hp <= 0)
            {
                enemyAudio.PlayOneShot(killed);
                Destroy(gameObject);
                Destroy(other.gameObject);
                gm.AddScore(1);
            }


            
           if (other.gameObject.CompareTag("Border"))
            {
                gm.LooseLife();
                Destroy(gameObject);
                if (gm.lives <= 0)
                {
                    pc.gameOver = true;
                    pc.moveSpeed = 0;
                    pc.Restart.gameObject.SetActive(true);
                    pc.deathTxt.gameObject.SetActive(true);
                    pc.levelController.gameObject.SetActive(true);
                }
            }
        }
    }
}
