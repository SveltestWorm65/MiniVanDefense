using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemy : MonoBehaviour
{
    [Header("Floats")]
    public float moveSpeed;

    [Header("Ints")]
    public int hp;

    [Header("Components")]
    public Rigidbody enemyRb;

    [Header("Scripts")]
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        //getting the components
        enemyRb = GetComponent<Rigidbody>();

        //getting the gameObjects and Scripts
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
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
      
        if (other.gameObject.CompareTag("Projectile"))
        {
            hp = hp - 1;
            Destroy(other.gameObject);
            if (hp <= 0)
            {
                Destroy(gameObject);
                Destroy(other.gameObject);
                gm.AddScore(2);
            }
         
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

    }
}

