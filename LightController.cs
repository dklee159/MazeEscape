using System.Collections;
using UnityEngine;


public class LightControll : MonoBehaviour
{
    
    public ParticleSystem particle;
    

    // Start is called before the first frame update
    void Start()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            particle.Play();
           this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
           this.gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        particle.Stop();
    }
}
