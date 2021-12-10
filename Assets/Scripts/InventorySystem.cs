using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    [System.Serializable]
    // Inventory item class
    public class InventoryItem
    {
        public GameObject obj;
        public int stack = 1;
        public InventoryItem(GameObject o, int s = 1)
        {
            obj = o;
            stack = s;
        }

    }
    [Header("General Fields")]
    // List of items picked up
    public List<InventoryItem> items = new List<InventoryItem>();
    // Flag indicates if the inventory is open or not
    public bool isOpen;
    [Header("UI Items Section")]
    // Inventory System Window
    public GameObject ui_Window;
    public Image[] items_images;
    [Header("UI Item Description")]
    public GameObject ui_Description_Window;
    public Image description_Image;
    public Text description_Title;
    public Text description_Text;
    private bool activitiesCheck = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            ToggleInventory();
        }
    }

    // Add item to the list
    public void PickUp(GameObject item)
    {
        // If item is stackable
        if (item.GetComponent<Item>().stackable)
        {
            // Check if we have an existing item in our inventory
            InventoryItem existingItem = items.Find(x => x.obj.name == item.name);
            // If so, stack it
            if (existingItem != null)
            {
                existingItem.stack++;
            }
            // If no, add it as new item
            else
            {
                InventoryItem i = new InventoryItem(item);
                items.Add(i);
            }
        }
        // If item is not stackable
        else
        {
            InventoryItem i = new InventoryItem(item);
            items.Add(i);
        }
        Debug.Log("you picked up " + item.name);
        FindObjectOfType<PlayerManager>().doingTask(item.name.ToString());
        Update_UI();
    }

    public bool CanPickUp()
    {
        if (items.Count >= items_images.Length)
        {
            return false;
        }
        else
        {
            return true;
        }
    }


    public void ToggleInventory(bool checksTask = false)
    {
        isOpen = !isOpen;
        Debug.Log(checksTask);
        activitiesCheck = checksTask;
        ui_Window.SetActive(isOpen);
        Update_UI();
    }

    // Refresh the UI elements in the inventory window
    void Update_UI()
    {
        HideAll();
        // For each item in the "items" list
        // Show it in the respective slot in the "items_images"
        for (int i = 0; i < items.Count; i++)
        {
            items_images[i].sprite = items[i].obj.GetComponent<SpriteRenderer>().sprite;
            items_images[i].gameObject.SetActive(true);
        }
    }

    // Hide all the items ui images
    void HideAll()
    {
        foreach (var i in items_images)
        {
            i.gameObject.SetActive(false)   ;
        }
        HideDescription();
    }

    public void ShowDescription(int id)
    {
        // Set the  image
        description_Image.sprite = items_images[id].sprite;
        // Set the title
        // If stack == 1 just write name
        if (items[id].stack == 1)
            description_Title.text = items[id].obj.name;
        // If stack >= 1 write name + x value
        else
            description_Title.text = items[id].obj.name + " x" + items[id].stack;
        // Show the description
        description_Text.text = items[id].obj.GetComponent<Item>().descriptionText;
        // Show the elements
        description_Image.gameObject.SetActive(true);
        description_Title.gameObject.SetActive(true);
        description_Text.gameObject.SetActive(true);
    }

    public void HideDescription()
    {
        description_Image.gameObject.SetActive(false);
        description_Title.gameObject.SetActive(false);
        description_Text.gameObject.SetActive(false);
    }
    public void Consume(int id)
    {
        if (items[id].obj.GetComponent<Item>().itemType == Item.ItemType.Consumable)
        {
            Debug.Log($"CONSUMED {items[id].obj.name}");
            if (activitiesCheck)
                FindObjectOfType<PlayerManager>().doingTaskActivities(items[id].obj.name);
            activitiesCheck = false;
            // Invoke the consume custom event 
            items[id].obj.GetComponent<Item>().consumeEvent.Invoke();
            // Reduce the stack number
            items[id].stack--;
            // If the stack equals zerr
            if (items[id].stack == 0)
            {
                // Destroy the item in very little time
                Destroy(items[id].obj, 0.1f);
                // Clear the item from the list
                items.RemoveAt(id);
            }
            // Update UI
            Update_UI();
        }
    }
}
