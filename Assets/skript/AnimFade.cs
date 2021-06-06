using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimFade : MonoBehaviour
{
    private void Update()
    {

        if(Player.FadeAnim == true)
        {
            GetComponent<Animator>().SetTrigger("end");
        }
    }
}
