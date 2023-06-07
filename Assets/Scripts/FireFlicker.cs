using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlicker : MonoBehaviour
{

    public float standardIntense; // default brightness set for each object
    public float currentIntense; // how bright it currently is flickering around
    Light thisFlame;
    float amp = 0.3f;
    float strength = 100;
    float dampen = 0.1f;
    bool flickering = false;

    private void Start()
    {
        thisFlame = gameObject.GetComponent<Light>();
        standardIntense = thisFlame.intensity;
        currentIntense = thisFlame.intensity;
        strength *= thisFlame.range;
    }

    private void Update()
    {
        if (currentIntense != 0 && flickering == false)
        {
            StartCoroutine(nameof(FlickerFlame));
        }
    }

    private IEnumerator FlickerFlame()
    {
        flickering = true;
        while (currentIntense != 0)
        {
            thisFlame.intensity = Mathf.Lerp(thisFlame.intensity, Random.Range(currentIntense - amp, currentIntense + amp), strength * Time.deltaTime);
            yield return new WaitForSeconds(dampen);
        }
        flickering = false;
    }

}
