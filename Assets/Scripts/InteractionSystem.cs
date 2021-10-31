using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    [Header("Others")]
    // List of picked items
    public List<GameObject> pickedItems = new List<GameObject>();                       // List to store items (inventory *kinda)

    // Update is called once per frame
    void Update()
    {
        if (DetectObject())
        {
            if(InteractInput())
            {
                detectedObject.GetComponent<Item>().Interact();                                                // Once detect an object open Item script and call Interact
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

    // Function to pick up items
    public void PickUpItem(GameObject item)
    {
        pickedItems.Add(item);
    }

}
