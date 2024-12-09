using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Variables")]
    public float moveSpeed;
    public float horizontalInput;
    private float verticalInput;

    [Header("GameObjects")]
    public GameObject projectilePrefab;

    [Header("Components")]
    public Rigidbody rb;
    public AudioSource audioSource;
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

    }
}
