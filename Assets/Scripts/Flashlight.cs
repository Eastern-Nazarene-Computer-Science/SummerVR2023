using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Flashlight : MonoBehaviour
{
    public Light spotLight; // light object in flashlight
    public Material lightLens; // flashlight lens material

    private void Start() // for some reason the flashlight needs to start on in runtime
    {
        FlashlightOff();
    }

    public void FlashlightToggle()
    {
        LocalKeyword _v = lightLens.shader.keywordSpace.FindKeyword("_EMISSION"); // this is dumb
        spotLight.enabled = !spotLight.enabled; // set to whatever it is not
        lightLens.SetKeyword(_v, !lightLens.IsKeywordEnabled("_EMISSION")); // set _v to whatever it is not
    }

    public void FlashlightOff()
    {
        spotLight.enabled = false; // turner offer
        lightLens.DisableKeyword("_EMISSION"); // another one
    }
    public void FlashlightOn()
    {
        spotLight.enabled = true; // turner oner
        lightLens.EnableKeyword("_EMISSION"); // another one
    }
}
