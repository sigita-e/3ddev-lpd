using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animacijas_skripts : MonoBehaviour
{
    public Animator animacija;

    void Start()
    {
        animacija = GetComponent<Animator>();
    }


    void FixedUpdate()
    {


        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            animacija.Play("Animation_Bumbai_leksana");
        }
    
    }
}
