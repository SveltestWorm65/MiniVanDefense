using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerController : MonoBehaviour
{
    [Header("Limitations")]
    public float xRange;
    public float zRange;

    [Header("Movement Variables")]
    public float moveSpeed;
    public float horizontalInput;
    private float verticalInput;

    [Header("GameObjects")]
    public GameObject projectilePrefab;
    public GameObject projectileSpawner;

    [Header("Bools")]
    public bool gameOver = false;

    [Header("Scripts")]
    public GameManager gm;

    [Header("Components")]
    public Rigidbody rb;
    public AudioSource audioSource;

    [Header("Sounds")]
    public AudioClip pewpewClip;
    public AudioClip playerDamaged;

    [Header("UI Elements")]
    public TextMeshProUGUI deathTxt;
    public TextMeshProUGUI levelController;
    public Button Restart;
    // Start is called before the first frame update
    void Start()
    {
        //Getting the players components
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

        //getting the game objects and their components
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //moving vertically
        verticalInput = Input.GetAxis("Vertical");
        rb.AddRelativeForce(Vector3.forward * verticalInput * moveSpeed);

        //moving Horizontally
        horizontalInput = Input.GetAxis("Horizontal");
        rb.AddRelativeForce(Vector3.right * horizontalInput * moveSpeed);
    }

    public void Update()
    {
        //Shooting
        if (gameOver == false)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Shoot"))
            {
                Instantiate(projectilePrefab, projectileSpawner.transform.position, projectileSpawner.transform.rotation);
                audioSource.PlayOneShot(pewpewClip);
            }
        }

        //Keeping player in the x bound
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }   

      
    }
    private void OnCollisionEnter(Collision collision)
    {
/*        if(collision.gameObject.CompareTag("Enemy"))
        {
            gm.LooseLife();
            Destroy(collision.gameObject);
            if(gm.lives <= 0)
            {
                gameOver = true;
                moveSpeed = 0;
                Restart.gameObject.SetActive(true);
                deathTxt.gameObject.SetActive(true);
               
            }
        }*/
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            gm.LooseLife();
            Destroy(other.gameObject);
            if (gm.lives <= 0)
            {
                gameOver = true;
                moveSpeed = 0;
                Restart.gameObject.SetActive(true);
                deathTxt.gameObject.SetActive(true);
                levelController.gameObject.SetActive(true);
            }
        }
        
    }
}
