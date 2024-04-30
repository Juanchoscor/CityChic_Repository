using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ocultarTienda : MonoBehaviour
{
    public GameObject OcultarT;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
        OcultarT.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
        OcultarT.SetActive(false);
        }
    }

}
