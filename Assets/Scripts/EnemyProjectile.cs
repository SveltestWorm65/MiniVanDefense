using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [Header("Floats")]
    public float speed;
    public float destroyDelay;

    [Header("Components")]
    public Rigidbody rb;

    [Header("GameObjects")]
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        //getting the projectiles components
        rb = GetComponent<Rigidbody>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        //if the projectile goes off doesn't hit anything it deletes it's own self
        Destroy(gameObject, destroyDelay);
    }
    void FixedUpdate()
    {
        //making the projectile move
        rb.velocity = transform.forward * speed;
    }
   
}