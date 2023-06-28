using UnityEngine;
using System.Collections.Generic;


public class ItemSaver : MonoBehaviour
{
    private Dictionary<BodySocket, GameObject> savedItems = new Dictionary<BodySocket, GameObject>();

    public void SaveItem(BodySocket socket, GameObject item)
    {
        if (socket == null || item == null)
            return;

        // Check if an item is already saved for the socket
        if (savedItems.ContainsKey(socket))
        {
            // Remove the previous saved item
            RemoveSavedItem(socket);
        }

        // Save the new item
        savedItems.Add(socket, item);
        item.SetActive(false); // Deactivate the item to prevent it from being rendered

        UnityEngine.Debug.Log("Saved item: " + item.name + " in socket: " + socket.name);
    }

    public void RemoveSavedItem(BodySocket socket)
    {
        if (socket == null)
            return;

        // Check if an item is saved for the socket
        if (savedItems.ContainsKey(socket))
        {
            GameObject savedItem = savedItems[socket];
            savedItem.SetActive(true); // Activate the item to make it visible again

            savedItems.Remove(socket);

            UnityEngine.Debug.Log("Removed saved item from socket: " + socket.name);
        }
    }

    public void LoadSavedItems()
    {
        // Activate all saved items
        foreach (GameObject savedItem in savedItems.Values)
        {
            savedItem.SetActive(true);
        }

        UnityEngine.Debug.Log("Loaded saved items");
    }
}