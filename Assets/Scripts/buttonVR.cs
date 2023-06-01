using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class buttonVR : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    GameObject presser;
    GameObject chest_lid;
    AudioSource sound;
    bool isPressed;
    
    void Start()
    {
        sound = GetComponent<AudioSource>();
        isPressed = false;
    }
    private void OnTriggerEnter(collider other)
    {
        if (!isPressed)
        {
            button.transform.localPosition = new Vector3(0, 0.003f, 0);
            presser = other.gameobject;
            onPress.Invoke();
            sound.Play();
            isPressed = true;

        }
    }
    private void onTriggerExit(collider other)
    {
        if (other.gameObject == presser)
        {
            button.transform.localPosition = new Vector3(0, 0.015f, 0);
            onRelease.Invoke();
            isPressed = false;
        }
    }
    public void openChest()
    {
        chest_lid.transform.localPosition = new Vector3(0.5f, .5f, .5f);
    }
}
