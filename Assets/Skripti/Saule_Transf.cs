using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saule_Transf : MonoBehaviour
{
    public float atrums;
    public Light saule;
    public Color noKrasas;
    private Color uzKrasu = new Color(0.847f, 0.337f, 0.31f, 1);

    public float zimeJauna;
    public float zimeVeca;
    public float turpinasanas;

    void Start()
    {
        saule = gameObject.GetComponent<Light>();
        noKrasas = saule.color;
        StartCoroutine("SaulesKrasa");
    }


    IEnumerator SaulesKrasa()
    {
        turpinasanas = 0;
        float solis = 0.001f;

           while (turpinasanas < 1)
                {
                    saule.color = Color.Lerp(noKrasas, uzKrasu, turpinasanas);
                    turpinasanas = turpinasanas + solis;
                    yield return null;
                }
    }

        void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.back, atrums * Time.deltaTime);
        transform.LookAt(Vector3.zero);

        zimeJauna = Mathf.Sign(saule.transform.position.x);

        if (saule.transform.position.y < 0 && zimeJauna != zimeVeca)
        {
            StopCoroutine("SaulesKrasa");
            StartCoroutine("SaulesKrasa");
        }

        zimeVeca = zimeJauna;

        //sinusoida krasas maina
        //float t = Mathf.Sin(Time.time + Time.deltaTime);
        //saule.color = Color.Lerp(noKrasas, uzKrasu, t);
    }
}