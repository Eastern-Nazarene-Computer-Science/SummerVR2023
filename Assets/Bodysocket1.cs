public class Bodysocket1 : MonoBehaviour
{
    // Item properties and data
    public string itemName;
    public int itemQuantity;
    // ...

    public void SaveState()
    {
        // Save the relevant item properties or data
        PlayerPrefs.SetString("ItemName", itemName);
        PlayerPrefs.SetInt("ItemQuantity", itemQuantity);
        // ...
        PlayerPrefs.Save();
    }

    // Other methods and functionality of the Item class
    // ...
}
