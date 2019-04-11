using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animacijas_skripts : MonoBehaviour
{
    public Animator animacija;
    public float attalums;
    public GameObject Speletajs;
    public GameObject Artefakts;
    bool vertiba;


    void Start()
    {
        animacija = GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        attalums = Vector3.Distance(Speletajs.transform.position, Artefakts.transform.position);
        //if (Input.GetKeyDown(KeyCode.Space)) //piemers ar Space
        if (attalums <= 5.0f)
        {
            vertiba = true;
            animacija.SetBool("leksana", vertiba); 
        }
        else
        {
            vertiba = false;
            animacija.SetBool("leksana", vertiba);
        }

    }
}
