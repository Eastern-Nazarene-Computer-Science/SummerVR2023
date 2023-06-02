using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwapper : MonoBehaviour
{
    public string targetRoom;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger active");
        LoadRoom(targetRoom);
    }
    void LoadRoom(string toLoad)
    {
        SceneManager.LoadScene(toLoad);
    }
}
