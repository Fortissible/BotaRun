using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionSystem : MonoBehaviour
{
    [Header("Detection Parameters")]
    // Detection Point
    public Transform detectionPoint;
    // Detection Radius
    public const float detectionRadius = 0.38f;
    // Detection Layer
    public LayerMask detectionLayer;
    // Cached Trigger Object
    public GameObject detectedObject;
    [Header("Examine Fields")]
    // Examine window object
    public GameObject examineWindow;
    public Image examineImage;
    public Text examineText;
    public bool isExamining; 

    // Update is called once per frame
    void Update()
    {
        if (DetectObject())
        {
            if(InteractInput())
            {
                detectedObject.GetComponent<Item>().Interact();                        // Once detect an object open Item script and call Interact
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(detectionPoint.position, detectionRadius);
    }

    // Function to check keyboard input
    bool InteractInput()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    // Function to check if there's intersection between objects
    bool DetectObject()
    {
        Collider2D obj =  Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer);    // Return the collider
        if (obj == null)
        {
            detectedObject = null;
            return false;
        }
        else
        {
            detectedObject = obj.gameObject;
            return true;
        }
    }



    public void ExamineItem(Item item)
    {
        if (isExamining)
        {
            Debug.Log("CLOSE");
            // Hide an Examine Window
            examineWindow.SetActive(false);
            // Disable the boolean;
            isExamining = false;
        }
        else
        {
            Debug.Log("EXAMINE");
            // Show the item's image in the middle
            examineImage.sprite = item.GetComponent<SpriteRenderer>().sprite;       // Get sprite from Sprite Renderer
            examineText.text = item.descriptionText;                                // Write description text underneath the image
            // Display an Examine Window
            examineWindow.SetActive(true);
            // Enable the boolean;
            isExamining = true;
        }
    }
}
