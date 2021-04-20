using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool lockedByPassword;

    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void OpenClose()
    {
        /*if (lockedByPassword)
        {
            Debug.Log("Locked by password");
            return;
        }*/
        if(!lockedByPassword)
            anim.SetTrigger("Open");
    }

}
