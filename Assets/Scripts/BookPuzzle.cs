using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BookPuzzle : MonoBehaviour
{
    // Unfortunately, david's script went missing. this does the same thing.
    public CheckBook ivySocket, spaceSocket, starSocket, oceanSocket, fireSocket, earthSocket;
    public Animator doorAnimator;
    public void CheckAllBooks()
    {
        if(ivySocket.CheckProperBook() && spaceSocket.CheckProperBook() && starSocket.CheckProperBook() && oceanSocket.CheckProperBook() && fireSocket.CheckProperBook() && earthSocket.CheckProperBook())
        {
            doorAnimator.SetInteger("stateChange", 1);
        }
    }

}
