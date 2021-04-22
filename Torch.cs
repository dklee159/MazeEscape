using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    [SerializeField]
    ParticleSystem particle;
    [SerializeField]
    GameObject line;
    Line playertrig;

    
    // Start is called before the first frame update
    void Start()
    {
        playertrig = line.GetComponent<Line>();
        particle.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        if(playertrig.trigMe==true)
        {
            particle.Play();
            playertrig.trigMe = true;
        }
    }
}
