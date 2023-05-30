using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class LightSwitch : MonoBehaviour
{
    public Light spotLight; // light object in light emitter
    public Material lightMatEmis; // light emission mat
    public float lightIntens = 1; // intensity to set light to when on

    private void Start() // for some reason the light needs to start on in runtime
    {
        spotLight = (spotLight == null) ? gameObject.GetComponentInChildren<Light>() : spotLight; // if spotlight isn't set, it will find a light
        lightMatEmis = (lightMatEmis == null) ? gameObject.GetComponent<Material>() : lightMatEmis; // if lightlens isn't set, it will use the attached object material
        LightOff();
    }

    public void LightToggle()
    {
        LocalKeyword _v = lightMatEmis.shader.keywordSpace.FindKeyword("_EMISSION"); // this is dumb
        spotLight.intensity = (spotLight.intensity == 0) ? lightIntens : 0; // if intensity is 0, it equals lightIntens, else equals 0
        lightMatEmis.SetKeyword(_v, !lightMatEmis.IsKeywordEnabled("_EMISSION")); // set _v to whatever it is not
    }

    public void LightOff()
    {
        spotLight.intensity = 0; // turner offer
        lightMatEmis.DisableKeyword("_EMISSION"); // another one
    }
    public void LightOn()
    {
        spotLight.intensity = lightIntens; // turner oner
        lightMatEmis.EnableKeyword("_EMISSION"); // another one
    }
}
