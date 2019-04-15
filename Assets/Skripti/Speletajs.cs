using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public GameObject panelis;
    private bool saskarsme;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        skana = GetComponent<AudioSource>();
        artefSkaits = 0;
        RezultataTeksts();
        textLogsUzvara.text = "";
        textLogsSakums.text = "";
        panelis.GetComponent<CanvasGroup>();
        panelis.SetActive(false);
        saskarsme = true;
    }


    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float jump;

        if (Input.GetKeyDown(KeyCode.Space) && saskarsme) //rb.velocity.y == 0)
        {
            jump = jumpHeight;
            saskarsme = false;
        }
        else
            jump = 0;

        Vector3 movement = new Vector3(moveHorizontal, jump, moveVertical);

        rb.AddForce(movement * speed);

        if (rb.transform.position.y < 0)
        {
            textLogsUzvara.text = "Tu esi zaudējis!";
            panelaAktivitatesMaina();
            StartCoroutine("Pauze");

        }
    }

    void OnCollisionEnter(Collision other)
    {
        saskarsme = true;

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
        textLogsSkaits.text = "Skaits: " + artefSkaits.ToString() + "/6";
        if (artefSkaits >= 5)
        {
            textLogsUzvara.text = "Tu esi uzvarējis!";
            panelaAktivitatesMaina();
            StartCoroutine("Pauze");
    
        }
    }

    void panelaAktivitatesMaina()
    {
        panelis.SetActive(true);
        panelis.transform.GetChild(1).gameObject.SetActive(false);
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