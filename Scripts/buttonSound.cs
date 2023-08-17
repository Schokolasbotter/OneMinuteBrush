using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class buttonSound : MonoBehaviour
{
    public AudioClip buttonSoundClip;

    private void Start()
    {
        
    }

    public void playButtonSound()
    {
        GameObject.Find("Music").GetComponent<AudioSource>().PlayOneShot(buttonSoundClip);
    }
}
