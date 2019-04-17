using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Izvelne : MonoBehaviour {

    public static bool gameIsPaused = true;
    public GameObject izvelne;
    public GameObject pogas;
    public GameObject skaits;
    public Text textLogsSakums;

    void Update()
    {
        if (gameIsPaused)
        {
            Nopauzet();
        }
        
    }

    public void SaktSpelet()
    {
        izvelne.SetActive(false);
        pogas.SetActive(false);
        skaits.SetActive(true);
        textLogsSakums.text = "";
        Time.timeScale = 1f; //atsāk laiku
        gameIsPaused = false;
    }


    public void Nopauzet() 
    {
        izvelne.SetActive(true);
        pogas.SetActive(true);
        skaits.SetActive(false);
        Time.timeScale = 0f; //apstādina laiku
        gameIsPaused = true;
    }

    public void Iziet()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

Application.Quit(0);
    }
}
