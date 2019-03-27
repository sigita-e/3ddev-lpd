using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speletajs : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public float jumpHeight = 11.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float jump;

        if (Input.GetKeyDown(KeyCode.Space))
            jump = jumpHeight;
        else
            jump = 0;

        Vector3 movement = new Vector3(moveHorizontal, jump, moveVertical);

        rb.AddForce(movement * speed);
    }
}
