using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicFlare : MonoBehaviour
{
    // This just adds little sting sounds in music
    [Range(1, 5)] public int numSounds; // number of sounds to sting
    public AudioClip stingOne, stingTwo, stingThree, stingFour, stingFive;
    public float stingFreqMin, stingFreqMax; // how frequent stings are in sec
    public AudioSource thatOneGuy; // there's always one, sting source

    private AudioClip[] sounds;
    private void Start()
    {
        sounds = new AudioClip[]{ stingOne, stingTwo, stingThree, stingFour, stingFive };
        CallSting();
    }

    void CallSting()
    {
        int stingSelection = Random.Range(1, numSounds);
        thatOneGuy.PlayOneShot(sounds[stingSelection - 1]);

        float waitTime = Random.Range(stingFreqMin, stingFreqMax);
        Invoke("CallSting", waitTime); 
    }
}
