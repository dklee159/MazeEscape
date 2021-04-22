using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatStatue : MonoBehaviour
{
    [SerializeField]
    GameObject GateWall;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GateWall.SetActive(false);
        }
    }
}
