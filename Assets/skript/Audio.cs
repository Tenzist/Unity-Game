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
    public GameObject AudioOff;
    public GameObject AudioOn;

    public static bool soundbutton = true;

    private void Start()
    {
        aud = GetComponent<AudioSource>();
        if(soundbutton == false)
            AudioOff.SetActive(true);
        else
            AudioOn.SetActive(true);
    }

    private void Update()
    {
        if (soundbutton == false)
            aud.volume = 0;

        else
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
        if (soundbutton == false)
            aud.volume = 0;
        else
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



    public void audioOn()
    {
        soundbutton = false;
        AudioOff.SetActive(true);
        AudioOn.SetActive(false);
        aud.volume = 0f;
    }
    public void audioOff()
    {
        soundbutton = true;
        AudioOff.SetActive(false);
        AudioOn.SetActive(true);
        if (aud.volume < 0.1)
            aud.volume = 0.01f;
        else
            aud.volume = 1f;
    }
}
