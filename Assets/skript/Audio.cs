using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{   
    private AudioSource aud;

    public AudioClip auddeath;
    public AudioClip audfinish;
    public AudioClip jumping;

    private void Start()
    {
        aud = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Player.grounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            aud.PlayOneShot(jumping);
        }
    }

        void OnTriggerEnter2D(Collider2D other)
    {
        if (this.CompareTag("Player") && other.CompareTag("Finish"))
        {
            aud.PlayOneShot(audfinish);
        }   
        if (this.CompareTag("Player") && other.CompareTag("MapEnd"))
        {
            aud.PlayOneShot(auddeath);
        }
    }

 }
