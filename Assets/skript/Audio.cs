using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Audio : MonoBehaviour
{   
    public static AudioSource aud;

    public AudioClip auddeath;
    public AudioClip audfinish;
    public AudioClip jumping;
    public AudioClip walking;



    private void Start()
    {
        aud = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Time.timeScale >= 0.5)
        {
            if (Player.grounded == true && Input.GetKeyDown(KeyCode.Space))
            {
                aud.PlayOneShot(jumping);
            }
            if (Player.grounded == true && Player.moveInput != 0 && aud.isPlaying == false) 
            {
                aud.PlayOneShot(walking);
                aud.volume = Random.Range(0.8f, 1f);
                aud.pitch = Random.Range(0.9f, 1.1f);
            } 
        }
    }

        void OnTriggerEnter2D(Collider2D other)
    {
        if (this.CompareTag("Player") && other.CompareTag("Finish"))
        {
          //  aud.PlayOneShot(audfinish);
        }   
        if (this.CompareTag("Player") && other.CompareTag("MapEnd"))
        {
            aud.PlayOneShot(auddeath);
            aud.volume = 0.3f;
        }
    }

 }
