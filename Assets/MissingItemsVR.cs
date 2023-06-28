using UnityEngine;
using TMPro;

public class MissingItemsVR : MonoBehaviour
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
        // Check if any of the specified items are missing from the body sockets
        bool itemMissing = false;
        foreach (GameObject item in itemsToCheck)
        {
            bool itemFound = false;
            foreach (Transform socket in bodySocketsParent)
            {
                if (socket.childCount > 0 && socket.GetChild(0).gameObject == item)
                {
                    itemFound = true;
                    break;
                }
            }

            if (!itemFound)
            {
                itemMissing = true;
                break;
            }
        }

        // Enable or disable the text object based on item presence
        textObject.enabled = itemMissing;
    }
}
