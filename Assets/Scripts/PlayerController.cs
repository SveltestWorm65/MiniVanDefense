using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [Header("Components")]
    public Rigidbody rb;
    public AudioSource audioSource;

    [Header("Sounds")]
    public AudioClip pewpewClip;
    // Start is called before the first frame update
    void Start()
    {
        //Getting the players components
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
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
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Shoot"))
        {
            Instantiate(projectilePrefab, projectileSpawner.transform.position, projectileSpawner.transform.rotation);
            audioSource.PlayOneShot(pewpewClip);

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

        //keeping player in the z bound 
       /* if (transform.position.z < -5.15)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -5.15f);
        }
        if (transform.position.z > -7.5)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -5.15f);
        }*/
    }
}
