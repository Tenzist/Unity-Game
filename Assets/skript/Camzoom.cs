using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camzoom : MonoBehaviour
{
    public float zoom;
    public CinemachineCameraOffset vcam;

    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (this.CompareTag("Player") && other.CompareTag("CamTrigg"))
        {
           // vcam.m_Lens.OrthographicSize = 15f;

        }
    }
}
