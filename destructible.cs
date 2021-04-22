using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destructible : MonoBehaviour
{
    public GameObject GateWall;

    public float cubeSize = 0.2f;
    public int cubeInRow = 5;
    
    //float cubePivotDistance;
    //Vector3 cubePivot;

    public float explosionForce = 50f;
    public float explosionRadius = 4f;
    public float explosionUpward = 0.4f;

    void createPiece(float wallx,float wally, float wallz)
    {
        Transform tr = gameObject.GetComponent<Transform>();
        wallx = tr.localScale.x;
        wally = tr.localScale.y;
        wallz = tr.localScale.z;

        //crate piece
        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);

        //set piece position and scale
        piece.transform.position = transform.position;
        piece.transform.localScale = new Vector3(cubeSize,cubeSize,cubeSize);
        
        //add rigidbody and set mass
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;
    }
    // Update is called once per frame
    public void Destroy()
    {
        //make object disappear
        gameObject.SetActive(false);
        //loop 3 time to create 5x5x5 pieces in x,y,z coordinates
        for (int x = 0; x < cubeInRow; x++)
        {
            for(int y = 0; y < cubeInRow; y++)
            {
                for(int z = 0; z < cubeInRow; z++)
                {
                    createPiece(x,y,z);
                }
            }
        }
        //get explosion position
        Vector3 explosionPos = transform.position;
        //get colliders in taht position and radius
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        //add explosion force to all colliders in that overlap sphere
        foreach(Collider hit in colliders)
        {
            //get rigidbody from collider object
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                //add explosion force to this body with given parameter
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
            }
        }
    }
}
