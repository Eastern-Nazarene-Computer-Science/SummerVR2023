using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningHandle : MonoBehaviour
{

    // lightningOne is a bright flash that slowly fades out
    // lightningTwo is a bright flash followed by a few smaller flickers
    // lightningThree is a quick bright flash that is gone immediately

    public GameObject lightningSourceOne, lightningSourceTwo, lightningSourceThree, lightningSourceFour;
    public AudioClip thunderclap, thunderCrackle, thunderBoom;
    public AudioSource thunderSource;

    //private float lightFadeRate;
    //private float lightningOneFadeTime = 0.05f; // time to fade light level 
    private float lightningTwoFlash = 0.125f; // time for initial flash
    private float lightningTwoDuration = 0.025f; // duration of LightningTwo flashes
    private float lightningTwoGap = 0.125f; // time between flashes
    private float lightningThreeDuration = 0.125f; // duration of LightningThree flash
    private float lightningBrightest = 1f; // the brightest the lightning will get
    private float lightBrightTarget = 0;
    private GameObject selectedLightning;
    private float lightFreqMin = 3; // min time between strikes
    private float lightFreqMax = 9; // max time between strikes

    private void Start()
    {
        LightItUp();
    }

    void LightItUp()
    {
        int lightningIndex = Random.Range(0,3);

        int _LI = Random.Range(0, 3);

        switch (_LI)
        {
            case 0:
                selectedLightning = lightningSourceOne;
                break;
            case 1:
                selectedLightning = lightningSourceTwo;
                break;
            case 2:
                selectedLightning = lightningSourceThree;
                break;
            case 3:
                selectedLightning = lightningSourceFour;
                break;
        }
        
        switch (lightningIndex) // BrS wanted lightning 3 to happen more than lightning 2 hence the double
        {
            case 0:
                goto case 1;
            case 1:
                LightningThree();
                break;
            case 2:
                LightningTwo();
                break;
            case 3:
                break;
        }

        float v = Random.Range(lightFreqMin, lightFreqMax);
        Invoke("LightItUp", v);
    }
    
    void LightningTwo() // series of quick flashes
    {
        selectedLightning.GetComponent<Light>().intensity = lightningBrightest;
        LightsOn();
        Invoke("LightsOut", lightningTwoFlash);
        selectedLightning.GetComponent<Light>().intensity = lightningBrightest / 3;
        SummonCrackleThunder();
        StartCoroutine("Flicker");

    }
    
    IEnumerator Flicker()
    {
        GameObject flop = selectedLightning;
        flop.SetActive(true);
        yield return new WaitForSeconds(lightningTwoDuration);
        flop.SetActive(false);
        yield return new WaitForSeconds(lightningTwoGap);
        flop.SetActive(true);
        yield return new WaitForSeconds(lightningTwoDuration);
        flop.SetActive(false);
        yield return new WaitForSeconds(lightningTwoGap);
        flop.SetActive(true);
        yield return new WaitForSeconds(lightningTwoDuration);
        flop.SetActive(false);
    }

    void LightningThree() // quick flash then off
    {
        LightsOn();
        selectedLightning.GetComponent<Light>().intensity = lightningBrightest;
        Invoke("LightsOut", lightningThreeDuration);
        SummonThunder();
    }

    void LightIntensitySet()
    {
        selectedLightning.GetComponent<Light>().intensity = lightBrightTarget;
    }

    void LightsOn()
    {
        selectedLightning.SetActive(true);
    }

    void LightsOut()
    {
        selectedLightning.SetActive(false);
    }

    //I don't know how to make this work and it isn't worth it to keep trying
    /*IEnumerator LightFade() // Constant fade for lightningOne
    {
        GameObject _selLight = selectedLightning;
        float _lightIntensity = _selLight.GetComponent<Light>().intensity;
        float _target = lightBrightTarget;
        while (_lightIntensity > _target)
        {
            yield return new WaitForSeconds(lightningOneFadeTime);
            if(_lightIntensity <= lightFadeRate)
            {
                break;
            }
            _lightIntensity -= lightFadeRate;
            _selLight.GetComponent<Light>().intensity = _lightIntensity; 
        }
        LightsOut();

    }*/

    void SummonThunder()
    {
        float _K = Random.Range(0, 1);
        if(_K > 0.5f)
        {
            thunderSource.PlayOneShot(thunderclap);
        } else
        {
            thunderSource.PlayOneShot(thunderBoom);
        }
    }
    
    void SummonCrackleThunder()
    {
        thunderSource.PlayOneShot(thunderCrackle);
    }

}
