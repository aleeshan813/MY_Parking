using System;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sounds[] sfxsounds;
    public AudioSource sfxsource;

  
    public void demo()
    {
        Debug.Log("Hello");
    }
    public void PlaySFX(string name)
    {
        Sounds s = Array.Find(sfxsounds, x => x.name == name);

        if (s == null)
        {
            return;
        }

        else
        {
            sfxsource.PlayOneShot(s.Clip);
        }
    }

    public void ToggleSFX()
    {
        sfxsource.mute = !sfxsource.mute;
    }
    public void sfxVolume(float volume)
    {
        sfxsource.volume = volume;
    }
}

