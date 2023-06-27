using UnityEngine;

public class BodySocket : MonoBehaviour
{
    [SerializeField] private Transform attachmentPoint;
    private GameObject currentItem;

    public Transform AttachmentPoint => attachmentPoint;
    public GameObject Item => currentItem;

    public void AttachItem(GameObject item)
    {
        if (item == null)
            return;

        if (currentItem != null)
            DetachItem();

        currentItem = item;
        item.transform.SetParent(attachmentPoint);
        item.transform.localPosition = UnityEngine.Vector3.zero;
        item.transform.localRotation = UnityEngine.Quaternion.identity;

        UnityEngine.Debug.Log("Attached item: " + item.name + " to socket: " + name);
    }

    public void DetachItem()
    {
        if (currentItem != null)
        {
            currentItem.transform.SetParent(null);
            currentItem = null;

            UnityEngine.Debug.Log("Detached item from socket: " + name);
        }
    }
}
