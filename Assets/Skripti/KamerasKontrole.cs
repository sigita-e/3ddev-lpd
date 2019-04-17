using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamerasKontrole : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        //Kamera seko spēlētājam
        transform.position = player.transform.position + offset;
    }
}

