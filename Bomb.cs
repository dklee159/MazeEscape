using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bomb : MonoBehaviour
{
    public float delay = 3f;
    public float radius = 5f;
    public float force = 700f;
    float countdown;
    bool hasExploded = false;
    public GameObject explosioneffect;
    bool CollisionEnter = false;
    [SerializeField]
    AudioSource explosion;
    
    
    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            this.gameObject.GetComponent<Rigidbody>().useGravity = true;
            
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            CollisionEnter = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CollisionEnter == true)
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0f && !hasExploded)
            {
                Explode();
                hasExploded = true;
            }
        }
             
    }

    private void Explode()
    {
        Instantiate(explosioneffect, transform.position, transform.rotation);
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
            destructible dest = nearbyObject.GetComponent<destructible>();
            if (dest != null)
            {
                dest.Destroy();
            }
        }
        Destroy(gameObject);  
    }
}
