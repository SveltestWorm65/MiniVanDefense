using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Floats")]
    public float speed;
    public float destroyDelay;

    [Header("Components")]
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        //getting the projectiles components
        rb = GetComponent<Rigidbody>();
      
        //if the projectile goes off doesn't hit anything it deletes it's own self
        Destroy(gameObject, destroyDelay);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //making the projectile move
        rb.velocity = transform.forward * speed;
    }
}
