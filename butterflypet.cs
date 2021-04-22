using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class butterflypet : MonoBehaviour
{
    public Transform player;
    public float rotationSpeed;
    public float moveSpeed;
    public float arrivalDistance;
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        var lookpos = player.transform.position - transform.position;
        lookpos.y = 0;
        var rotation = Quaternion.LookRotation(lookpos);
        float distance = Vector3.Distance(transform.position, player.transform.position);

        

        if (distance >= arrivalDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed / 2);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        }
    }
}
