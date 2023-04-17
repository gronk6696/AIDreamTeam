using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource SoundEffectsAudioSource;

    private void Awake()
    {
        // Set up singleton pattern
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(string soundName)
    {
        // Load the audio clip from the Resources folder
        AudioClip clip = Resources.Load<AudioClip>(soundName);

        // Play the audio clip
        SoundEffectsAudioSource.clip = clip;
        SoundEffectsAudioSource.Play();

    }

}