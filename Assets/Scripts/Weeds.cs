using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weeds : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] audioClips;
    private int clipToPlay;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void WeedAudio()
    {
        clipToPlay = Random.Range(0, audioClips.Length - 1);
        audioSource.clip = audioClips[clipToPlay];
        audioSource.Play();
    }
}
