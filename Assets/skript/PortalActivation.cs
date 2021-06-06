using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalActivation : MonoBehaviour
{
    public GameObject Crystalik;
    public GameObject PortalOff;
    public GameObject PortalOn;

    void Start()
    {
        PortalOn.SetActive(true);
    }

    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (this.CompareTag("crystal") && other.CompareTag("Player"))
        {
            Destroy(Crystalik);
            PortalOff.SetActive(true);
            PortalOn.SetActive(false);
        }
    }
}
