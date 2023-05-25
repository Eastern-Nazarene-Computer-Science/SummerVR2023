using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningHandle : MonoBehaviour
{

    // lightningOne is a bright flash that slowly fades out
    // lightningTwo is a bright flash followed by a few smaller flickers
    // lightningThree is a quick bright flash that is gone immediately

    public GameObject lightningSourceOne, lightningSourceTwo, lightningSourceThree, lightningSourceFour;
    public AudioClip thunder;
    public AudioSource thunderSource;

    private float lightFadeRate;
    private float lightningOneFadeTime = 0.05f; // time to fade light level 
    private float lightningTwoDuration = 0.125f; // duration of LightningTwo flash
    private float lightningTwoGap = 0.125f; // time between flashes
    private float lightningThreeDuration = 0.125f; // duration of LightningThree flash
    private float lightningBrightest = 10.0f; // the brightest the lightning will get
    private float lightBrightTarget = 0;
    private GameObject selectedLightning;

    private void Start()
    {
        LightItUp();
    }

    void LightItUp()
    {
        int lightningIndex = Random.Range(0, 4);

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

        /*switch (lightningIndex)
        {
            case 0:
                LightningOne();
                break;
            case 1:
                LightningTwo();
                break;
            case 2:
                LightningThree();
                break;
            case 3:
                LightningOneTwo();
                break;
            case 4:
                //LightningThreeTwo();
                break;
            case 5:
                break;
        }*/

        LightningThree();

        float v = Random.Range(1, 8);
        Invoke("LightItUp", v);
    }

    void LightningOne() // bright flash then fade to off
    {
        selectedLightning.SetActive(true);
        selectedLightning.GetComponent<Light>().intensity = lightningBrightest;
        lightBrightTarget = 0;
        lightFadeRate = 0.1f;
        StartCoroutine("LightFade");
        
    }
    
    void LightningTwo() // series of quick flashes
    {
        selectedLightning.GetComponent<Light>().intensity = lightningBrightest;
        LightsOn();
        Invoke("LightsOut", lightningTwoDuration);
        selectedLightning.GetComponent<Light>().intensity = lightningBrightest / 2;
        Invoke("LightsOn", lightningTwoGap); 
        Invoke("LightsOut", lightningTwoDuration);
        Invoke("LightsOn", lightningTwoGap); 
        Invoke("LightsOut", lightningTwoDuration);
        Invoke("LightsOn", lightningTwoGap);
        Invoke("LightsOut", lightningTwoDuration);
    }

    void LightningOneTwo() // 
    {

        lightBrightTarget = lightningBrightest / 2;
        LightFade();
        lightBrightTarget = 0;
        Invoke("LightIntensitySet", lightningTwoGap);
        lightBrightTarget = lightningBrightest / 4 * 3;
        Invoke("LightIntensitySet", lightningTwoDuration);
        lightBrightTarget = 0;
        Invoke("LightIntensitySet", lightningTwoGap);
        lightBrightTarget = lightningBrightest / 4 * 3;
        Invoke("LightIntensitySet", lightningTwoDuration);
        lightBrightTarget = 0;
        Invoke("LightIntensitySet", lightningTwoGap);
        lightBrightTarget = lightningBrightest / 4 * 3;
        Invoke("LightIntensitySet", lightningTwoDuration);
        lightBrightTarget = 0;
        StartCoroutine("LightFade");
    }
    
    void LightningThree() // quick flash then off
    {
        selectedLightning.SetActive(true);
        selectedLightning.GetComponent<Light>().intensity = lightningBrightest;
        Invoke("LightsOut", lightningThreeDuration);
        SummonThunder();
    }
    
    void LightsOut() // Deactivate selLight
    {
        selectedLightning.SetActive(false);
    }

    void LightIntensitySet()
    {
        selectedLightning.GetComponent<Light>().intensity = lightBrightTarget;
    }

    void LightsOn()
    {
        selectedLightning.SetActive(true);
    }

    IEnumerator LightFade() // Constant fade for lightningOne
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

    }

    void SummonThunder()
    {
        thunderSource.PlayOneShot(thunder);
    }

}
