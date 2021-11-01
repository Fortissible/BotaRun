using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    public CharacterController2D controller;
    public float runSpeed = 100f;
    bool jump_bool = false;
    bool crouch = false;
    float horizontalMovement = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If player can't move don't execute code below this conditional statement
        if (!CanMove())
        {
            return;
        }

        horizontalMovement = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetButtonDown("Jump"))
        {
            jump_bool = true;
        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMovement * Time.fixedDeltaTime , crouch, jump_bool);
        jump_bool = false;
    }

    // Function to evaluate if the player can move or not
    bool CanMove()
    {
        bool can = true;

        if (FindObjectOfType<InteractionSystem>().isExamining)
            can = false;

        return can;
    }
}
