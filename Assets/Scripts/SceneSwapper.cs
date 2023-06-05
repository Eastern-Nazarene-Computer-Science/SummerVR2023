using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwapper : MonoBehaviour
{
    public Scene nextRoom;
    void LoadRoom(Scene toLoad)
    {
        SceneManager.LoadScene(nameof(toLoad));
    }
}
