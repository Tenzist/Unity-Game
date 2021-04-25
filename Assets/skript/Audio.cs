using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{   
    private AudioSource audio;

    public AudioClip audiodeath;
    public AudioClip audiofinish;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    private void Update()
    {

    }

        void OnTriggerEnter2D(Collider2D other)
    {
        if (this.CompareTag("Player") && other.CompareTag("Finish"))
        {
            audio.PlayOneShot(audiofinish);
        }
        if (this.CompareTag("Player") && other.CompareTag("MapEnd"))
        {
            audio.PlayOneShot(audiodeath);
        }
    }

 }
