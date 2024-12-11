using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemy : MonoBehaviour
{
    [Header("Floats")]
    public float moveSpeed;

    [Header("Components")]
    public Rigidbody enemyRb;
    // Start is called before the first frame update
    void Start()
    {
        //getting the components
        enemyRb = GetComponent<Rigidbody>();

        
    }

    // Update is called once per frame
    void Update()
    {
       

        //take damage if they reach a line
        if (transform.position.z < -5.15)
        {

        }
    }
    private void FixedUpdate()
    {
        //getting the enemies moving down
        enemyRb.AddForce(Vector3.forward * -moveSpeed, ForceMode.Acceleration);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
