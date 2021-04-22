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
        if(!lockedByPassword)
            anim.SetTrigger("Open");
    }

}
