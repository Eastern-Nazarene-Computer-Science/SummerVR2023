using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BookPuzzleHandler : MonoBehaviour
{
    public GameObject[] socketObjects; // Array of socket objects
    public GameObject door; // Reference to the door object
    public GameObject[] desiredPattern; // Array of transforms representing the desired pattern
    public Animator DoorAnimations;

    private int currentIndex = 0; // Current index in the desired pattern

    public void CheckPattern()
    {

        int truthCounter = 0;
        for (int i = 0; i < desiredPattern.Length; i++)
        {
            IXRSelectInteractable objname = socketObjects[i].GetComponent<XRSocketInteractor>().GetOldestInteractableSelected();
            if (objname == desiredPattern[i].GetComponent<IXRSelectInteractable>())
            {
                truthCounter++;
            }
        }
        if (truthCounter == desiredPattern.Length)
        {
            DoorAnimations.SetInteger("stateChange", 1);
            Debug.Log("SUCCESS!!!");
        }
        else
        {
            print("You are not succeding... yet");
        }
    }

    /*public void OnTriggerEnter(Collider other)
    {
        // Check if the collided object is in the desired pattern and in the correct socket
        Debug.Log("OnTriggerEnter");
        if (currentIndex < desiredPattern.Length && other.transform == desiredPattern[currentIndex] && IsInSocket(other.gameObject))
        {
            currentIndex++;

            if (currentIndex == desiredPattern.Length)
            {
                DoorAnimations.SetInteger("stateChange", 1);
                Debug.Log("stateChange 1");
                print("The door has been open");
            }
        }
        else
            print("This is not other correct pattern");
    }*/
    /*
    public bool IsInSocket(GameObject obj)
    {
        // Check if the object is placed in one of the sockets
       
        foreach (GameObject socket in socketObjects)
        {
            Collider socketCollider = socket.GetComponent<Collider>();
            if (socketCollider.bounds.Contains(obj.transform.position))
            {
                Debug.Log("IsInSocket");
                return true;
            }
        }
        return false;
    }*/
}