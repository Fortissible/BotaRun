using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]                                       // RequireComponent - add component when the script is assigned to an object
public class Item : MonoBehaviour
{
    public enum InteractionType { NONE, PickUp, Examine, Talk_or_Read, Task, Finish, Do}    // List of interaction type
    public enum ItemType { Static, Consumable}    // List of item type
    [Header("Attributes")]
    public InteractionType type;
    public ItemType itemType;
    public bool stackable;  
    [Header("Examine")]
    public string descriptionText;
    [Header("Custom Events")]
    public UnityEvent customEvent;
    public UnityEvent consumeEvent;
    public Dialog dialog;
    public GameObject gate;
    public Animator animator;

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
                if (!FindObjectOfType<InventorySystem>().CanPickUp())
                    return;
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

            case InteractionType.Do:
                // Call the Examine item in the interaction system
                gate.SetActive(false);
                animator.SetBool("isActive",true);
                break;

            case InteractionType.Finish:
                if (FindObjectOfType<TaskManager>().task.isCleared == false)
                {
                    FindObjectOfType<InteractionSystem>().ExamineItem(this);
                }

                else
                {
                    FindObjectOfType<Finish>().OpenClearWindow();
                }
                break;

            default:
                Debug.Log("NULL ITEM");
                break;
        }

        // Invoke (call) the custom event(s)
        customEvent.Invoke();
    }
}
