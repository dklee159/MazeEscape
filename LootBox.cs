using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBox : MonoBehaviour
{
    public GameObject TreasureBox;
    public Transform Go_Spawn;
    [SerializeField]
    public GameObject LootItem;

    private Animator CheckedOpen;

    // Start is called before the first frame update
    void Start()
    {
        CheckedOpen = GetComponentInChildren<Animator>();
        LootItem.SetActive(false);
    }

    public void IsBoxOpen()
    {
        if (CheckedOpen.GetBool("IsOpen") == true)
        {
            SpawnItem();
        }
    }
    private void SpawnItem()
    {
        GameObject clone = Instantiate(TreasureBox, Go_Spawn.position, Go_Spawn.rotation) as GameObject;
        OnEvent();
        
    }

    public void OnEvent()
    {
        LootItem.SetActive(true);
    }
}
