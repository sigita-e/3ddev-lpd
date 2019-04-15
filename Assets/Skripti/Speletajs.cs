using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speletajs : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public float jumpHeight;
    private int artefSkaits;
    public Text textLogsSkaits;
    public Text textLogsUzvara;
    public Text textLogsSakums;
    private AudioSource skana;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        skana = GetComponent<AudioSource>();
        artefSkaits = 0;
        RezultataTeksts();
        textLogsUzvara.text = "";
        textLogsSakums.text = "";
    }

    
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float jump;

        if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y == 0)
            jump = jumpHeight;
        else
            jump = 0;

        Vector3 movement = new Vector3(moveHorizontal, jump, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Lek_bumba"))
        {
            other.gameObject.SetActive(false);
            artefSkaits = artefSkaits + 1;
            skana.Play();
            RezultataTeksts();
        }
        
    }

    void RezultataTeksts()
    {
        textLogsSkaits.text = "Skaits: " + artefSkaits.ToString();
        if (artefSkaits >= 5)
        {
            textLogsUzvara.text = "Tu esi uzvarējis!";
            StartCoroutine("Pauze");
    
        }
    }

    IEnumerator Pauze()
    {
        yield return new WaitForSeconds(3);
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
        //Application.Quit(0);
    }
}