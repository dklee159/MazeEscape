using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractPlayer : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;
    private Animator _animator;
    private BoxCollider coll;
    public int count;

    public GameObject TreasureBox;
    public GameObject LootItem;
    Transform tr;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        audioSource.Stop();
        count = 0;
        tr = LootItem.GetComponent<Transform>();
    }

    public void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            count++;
            if (count == 1)
            {
                audioSource.Play();
                _animator.SetBool("isOpen", true);
                StartCoroutine(delayTime());
            }
        }
    }
    public void Loot()
    {        
        tr.position =new Vector3(transform.position.x-1,transform.position.y+1,transform.position.z);   
        tr.rotation = TreasureBox.transform.rotation;
        LootItem.SetActive(true);
        Rigidbody rg = LootItem.GetComponent<Rigidbody>();
        rg.isKinematic = true;
    }
    IEnumerator delayTime()
    {
        yield return new WaitForSeconds(1.2f);
        Loot();
    }
}
