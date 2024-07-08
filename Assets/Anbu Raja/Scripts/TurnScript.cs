using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnScript : MonoBehaviour
{

    [SerializeField]
    private AudioSource AudioSource;



    public void AudioPlay(AudioClip clip)
    {
        AudioSource.clip = clip;
        AudioSource.Play();
    }

}
