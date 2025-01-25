using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audiomanager : MonoBehaviour
{
    public AudioSource audiosource;
   public void Playmusic()
    {
        if (audiosource != null && !audiosource.isPlaying)
        {
            audiosource.Play();
        }
    }
}
