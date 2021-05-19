using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Audio : MonoBehaviour
{   
    public static AudioSource aud;

    public AudioClip auddeath;
    public float dethvol = 0.3f;
    public AudioClip audfinish;
    public AudioClip jumping;

 
    private void Start()
    {
        aud = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Time.timeScale >= 0.5) { 
        if (Player.grounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            aud.PlayOneShot(jumping);
        }}
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
            aud.volume = dethvol;
        }
    }

 }
