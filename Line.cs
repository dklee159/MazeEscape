using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public bool trigMe;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Me")
        {
            trigMe = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
