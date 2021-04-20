using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadKey : MonoBehaviour
{
    public string key;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SendKey();
        }
    }
    public void SendKey()
    {
        this.transform.GetComponentInParent<KeypadController>().PasswordEntry(key);
    }

}
