
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    public string initialSceneName = "InitialScene"; // Name of the initial scene

    public void Reset()
    {
        SceneManager.LoadScene(initialSceneName);
    }
}

