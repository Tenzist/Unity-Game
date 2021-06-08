using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudButton : MonoBehaviour
{
    void Update()
    {
        if (Audio.soundbutton == false)
            GetComponent<AudioSource>().volume = 0f;
        else
            GetComponent<AudioSource>().volume = 0.133f;
    }
}
