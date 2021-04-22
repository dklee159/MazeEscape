using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorVanish : MonoBehaviour
{
    public Material transparentMat;
    private Material primaryMat;
    private bool isTrig;

    
    void SetToPrimaryMaterial()
    {
        GetComponent<Renderer>().material = primaryMat;
    }
    void SetToTransparentMaterial()
    {
        GetComponent<Renderer>().material = transparentMat;
    }
    // Start is called before the first frame update
    void Start()
    {
        primaryMat = GetComponent<Renderer>().material;
        isTrig = GetComponent<BoxCollider>().isTrigger;
    }
      
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Light")
        {
            SetToTransparentMaterial();
            isTrig = true;
        }
        if (other.tag == "Player" || other.tag == "Me")
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Me")
        {
            GetComponent<MeshRenderer>().enabled = true;
            
        }
    }

}
