using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    // Detection Point
    public Transform detectionPoint;
    // Detection Radius
    public const float detectionRadius = 0.2f;
    // Detection Layer
    public LayerMask detectionLayer;

    // Update is called once per frame
    void Update()
    {
        if (DetectObject())
        {
            if(InteractInput())
            {
                Debug.Log("INTERACT");
            }
        }
    }

    // Function to check keyboard input
    bool InteractInput()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    // Function to check if there's intersection between objects
    bool DetectObject()
    {
        return Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(detectionPoint.position, detectionRadius);    
    }
}
