using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioClip[] musicSounds, sfxSounds;
    public AudioSource musicSource, SFXSource;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            PlaySFXMusic();

        }
        
    }

    public void PlayMusic()
    {
        //Sound sound_= Array.Find(musicSounds, x=>x.name ==name);
        AudioClip audio=Array.Find(musicSounds,x=>x.name == name);
        if (audio==null)
        {
            Debug.Log("Sound not found :[");
        }
        else
        { musicSource.Play();
        }

       
        
    }

    public void PlaySFXMusic()
    {
        //Sound sound_ = Array.Find(sfxSounds, x => x.name ==name);
        AudioClip audio= Array.Find(sfxSounds, x => x.name == name);
        if (audio==null)
        {
            Debug.Log("Sound not found :[");
        }
        else
        {
            
                SFXSource.PlayOneShot(audio);

            
            
        }
    }
}
