using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AUDIOHANDLER : MonoBehaviour
{
    public GameObject ducks;
    public GameObject tygers;

    public GameObject penguins;
    public GameObject background;
    AudioSource penguinsAudioSource;
    AudioSource tygersAudioSource; 
    AudioSource ducksAudioSource; 
    AudioSource backgroundAudioSource; 

    // Start is called before the first frame update
    void Start()
    {
        penguinsAudioSource = penguins.GetComponent<AudioSource>();
        tygersAudioSource = tygers.GetComponent<AudioSource>();
        ducksAudioSource = penguins.GetComponent<AudioSource>();
        backgroundAudioSource = background.GetComponent<AudioSource>();
        enableBackground();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void enablePenguinos(){
        tygersAudioSource.mute  = true;
        penguinsAudioSource.mute  = false;
        ducksAudioSource.mute  = true;
        backgroundAudioSource.mute  = true;


    }

    void enableBackground(){
        tygersAudioSource.mute  = true;
        penguinsAudioSource.mute  = true;
        ducksAudioSource.mute  = true;
        backgroundAudioSource.mute  = false;


    }

    void enableTygers(){
        tygersAudioSource.mute  = false;
        penguinsAudioSource.mute  = true;
        ducksAudioSource.mute  = true;
        backgroundAudioSource.mute  = true;
        


    }

    void enableDucks(){
        tygersAudioSource.mute  = true;
        penguinsAudioSource.mute  = true;
        ducksAudioSource.mute  = false;
        backgroundAudioSource.mute  = true;

    }
}
