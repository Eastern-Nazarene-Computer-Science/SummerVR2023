using UnityEngine;
using TMPro;

public class ItemPresenceVR : MonoBehaviour
{
    public Transform bodySocketsParent;
    public GameObject[] itemsToCheck;
    public TextMeshProUGUI textObject;

    private void Start()
    {
        textObject.enabled = false;
    }

    private void Update()
    {
        // Check if any of the specified items are present in the body sockets
        bool itemPresent = false;
        foreach (Transform socket in bodySocketsParent)
        {
            foreach (GameObject item in itemsToCheck)
            {
                if (socket.childCount > 0 && socket.GetChild(0).gameObject == item)
                {
                    itemPresent = true;
                    break;
                }
            }

            if (itemPresent)
                break;
        }

        // Enable or disable the text object based on item presence
        textObject.enabled = itemPresent;
    }
}
