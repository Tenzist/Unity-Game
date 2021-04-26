using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camzoom : MonoBehaviour
{
    public float zoom;

    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (this.CompareTag("Player") && other.CompareTag("CamTrigg"))
        {
           // Camera.sensorSize = zoom;
            Debug.Log("asd  ") ;
            zoom = zoom * 2;
        }
    }
}
