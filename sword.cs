using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour
{
    public float attackAmount = 50.0f;
    public AudioClip swordClip;
    AudioSource swordAudio;
    // Start is called before the first frame update
    void Start()
    {
        swordAudio = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Monster")
        {
            MonsterCtrl zombie = other.GetComponent<MonsterCtrl>();
            if (zombie != null)
            {
                zombie.GetDamage(attackAmount);
            }
            swordAudio.PlayOneShot(swordClip);

        }
    }
}
