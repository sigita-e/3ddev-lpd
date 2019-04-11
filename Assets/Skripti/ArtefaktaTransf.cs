using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtefaktaTransf : MonoBehaviour
{
    int skaitlis = 3;
    public GameObject artef;
    public Vector3 virziens;

    private void Start()
    {
        int koord1 = Random.Range(-1 * skaitlis, skaitlis);
        int koord2 = Random.Range(-1 * skaitlis, skaitlis);
        int koord3 = Random.Range(-1 * skaitlis, skaitlis);
        virziens = new Vector3(koord1, koord2, koord3);
    }

    void Update()
    {
        artef.transform.Rotate(virziens);
    }

}
