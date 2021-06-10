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
            if (GetComponent<AudioSource>().volume == 0.4f)
                GetComponent<AudioSource>().volume = 0.4f;
            else
                GetComponent<AudioSource>().volume = 0.133f;
    }
}
