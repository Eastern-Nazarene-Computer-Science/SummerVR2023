using UnityEngine;

public class ItemSaverTrigger : MonoBehaviour
{
    public string targetRoom;
    private ItemSaver itemSaver;

    private void Start()
    {
        itemSaver = FindObjectOfType<ItemSaver>();
    }

    private void OnTriggerEnter(Collider other)
    {
        UnityEngine.Debug.Log("Trigger activated");
        SaveItemsInBodySockets();
        LoadRoom(targetRoom);
    }

    private void LoadRoom(string toLoad)
    {
        // Perform your scene loading logic here
        UnityEngine.Debug.Log("Loading room: " + toLoad);
    }

    private void SaveItemsInBodySockets()
    {
        // Get all body sockets in the scene
        BodySocket[] bodySockets = FindObjectsOfType<BodySocket>();

        foreach (BodySocket socket in bodySockets)
        {
            // Check if an item is attached to the socket
            if (socket.Item != null)
            {
                // Save the item in the ItemSaver
                itemSaver.SaveItem(socket, socket.Item);
            }
        }
    }
}
