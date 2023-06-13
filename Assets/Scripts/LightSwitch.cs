using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class LightSwitch : MonoBehaviour
{
    public Light spotLight; // light object in light emitter
    public Material lightMatEmis; // light emission mat
    public float lightIntens = 1; // intensity to set light to when on
    bool isFire; // if it is fire or lightbulb
    public GameObject flameObj;

    private void Start() // for some reason the light needs to start on in runtime
    {
        spotLight = (spotLight == null) ? gameObject.GetComponentInChildren<Light>() : spotLight; // if spotlight isn't set, it will find a light
        lightMatEmis = (lightMatEmis == null) ? gameObject.GetComponent<Material>() : lightMatEmis; // if lightlens isn't set, it will use the attached object material
        isFire = (gameObject.GetComponentInChildren<FireFlicker>()) ? true : false;
        LightOff();
    }

    private void OnDestroy()
    {
        LocalKeyword _v = lightMatEmis.shader.keywordSpace.FindKeyword("_EMISSION"); // this is dumb
        lightMatEmis.SetKeyword(_v, true); // set _v to whatever it is not
    }

    public void LightToggle()
    {
        LocalKeyword _v = lightMatEmis.shader.keywordSpace.FindKeyword("_EMISSION"); // this is dumb
        if (spotLight.intensity == 0) // if its off then turn on
        {
            spotLight.intensity = lightIntens; 
            if (isFire)
            {
                gameObject.GetComponentInChildren<FireFlicker>().currentIntense = gameObject.GetComponentInChildren<FireFlicker>().standardIntense;
                flameObj.SetActive(!flameObj.activeSelf);
            }
        }
        else // if its on then turn off
        {
            spotLight.intensity = 0;
            if (isFire)
            {
                gameObject.GetComponentInChildren<FireFlicker>().currentIntense = 0;
                flameObj.SetActive(!flameObj.activeSelf);
            }
        }
        //spotLight.intensity = (spotLight.intensity == 0) ? lightIntens : 0; // if intensity is 0, it equals lightIntens, else equals 0
        lightMatEmis.SetKeyword(_v, !lightMatEmis.IsKeywordEnabled("_EMISSION")); // set _v to whatever it is not
    }

    public void LightOff()
    {
        spotLight.intensity = 0; // turner offer
        lightMatEmis.DisableKeyword("_EMISSION"); // another one
        if (isFire)
        {
            flameObj.SetActive(false);
            gameObject.GetComponentInChildren<FireFlicker>().currentIntense = 0;
        }
    }
    public void LightOn()
    {
        spotLight.intensity = lightIntens; // turner oner
        lightMatEmis.EnableKeyword("_EMISSION"); // another one
        if (isFire)
        {
            flameObj.SetActive(true);
            gameObject.GetComponentInChildren<FireFlicker>().currentIntense = gameObject.GetComponentInChildren<FireFlicker>().standardIntense;
        }
    }
}
