using UnityEngine.Audio;
using UnityEngine;
using Unity.VisualScripting;
using System;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    public static AudioManager instance;

    void Awake()
    {
        if (instance == null)
        { instance = this; }
        else
        { 
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound sound in sounds)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.clip;

            sound.audioSource.volume = sound.volume;
            sound.audioSource.pitch = sound.pitch;
        }
    }

    public void PlaySound(string name)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == name);
        if (sound == null)
        {
            Debug.Log("Sound: " + name +" not found!");
            return;
        }
        Debug.Log("Sound: " + name + " played!");
    }

    //FindObjectOfType<AudioManager>().PlaySound("SoundName");
}
