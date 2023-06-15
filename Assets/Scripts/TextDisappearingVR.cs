using UnityEngine;
using TMPro;

public class TextDisappearingVR : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public GameObject key;

    private bool hasKey = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == key)
        {
            hasKey = true;
            textMesh.enabled = false;
        }
    }
}
