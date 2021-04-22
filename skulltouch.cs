using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skulltouch : MonoBehaviour
{
    public GameObject treasurebox;
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            treasurebox.SetActive(true);
        }
    }
}
