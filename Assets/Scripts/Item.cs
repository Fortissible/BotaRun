using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]                                       // RequireComponent - add component when the script is assigned to an object
public class Item : MonoBehaviour
{
    public enum InteractionType { NONE, PickUp, Examine, Talk_or_Read, Task}                       // List of interaction type
    public InteractionType type;
    [Header("Examine")]
    public string descriptionText;
    public UnityEvent customEvent;
    public Dialog dialog;

    public void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;                            // set "is Trigger" to true
        gameObject.layer = 6;                                                   // set game object layer to item layer
    }

    public void Interact()
    {
        switch (type)
        {
            case InteractionType.NONE:
                break;
                
            case InteractionType.PickUp:
                // Add the object to the PickedUpItems list
                FindObjectOfType<InventorySystem>().PickUp(gameObject);   // Find object in a scene with a specific type
                // Disable the object
                gameObject.SetActive(false);                                    // Make game object inactive
                break;

            case InteractionType.Examine:
                // Call the Examine item in the interaction system
                FindObjectOfType<InteractionSystem>().ExamineItem(this);
                break;

            case InteractionType.Talk_or_Read:
                // Call the Examine item in the interaction system
                FindObjectOfType<DialogueSystem>().StartDialog(dialog);
                break;

            case InteractionType.Task:
                // Call the Examine item in the interaction system
                FindObjectOfType<TaskManager>().OpenTaskWindow();
                break;

            default:
                Debug.Log("NULL ITEM");
                break;
        }

        // Invoke (call) the custom event(s)
        customEvent.Invoke();
    }
}
