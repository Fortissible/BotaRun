using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    public CharacterController2D controller;
    public float runSpeed = 100f;
    public bool jump_bool = false;
    bool crouch = false;
    float horizontalMovement = 0f;
    public Animator animator;
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
        animator.SetFloat("isRunning", Mathf.Abs(horizontalMovement));

        if (Input.GetButtonDown("Jump"))
        {
            jump_bool = true;
            FindObjectOfType<CharacterController2D>().isJumpChange(jump_bool);
            animator.SetBool("isJumping", true);
        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }

    public void OnCrouching(bool Crouching)
    {
        animator.SetBool("isCrouching", Crouching);
    }


    void FixedUpdate()
    {
        controller.Move(horizontalMovement * Time.fixedDeltaTime , crouch, jump_bool);
        jump_bool = false;
        FindObjectOfType<CharacterController2D>().isJumpChange(jump_bool);
    }

    // Function to evaluate if the player can move or not
    bool CanMove()
    {
        bool can = true;

        if (FindObjectOfType<InteractionSystem>().isExamining)
            can = false;
        if (FindObjectOfType<InventorySystem>().isOpen)
            can = false;
        if (FindObjectOfType<TaskManager>().isReadTask)
            can = false;
        if (FindObjectOfType<DialogueSystem>().isDialogActive)
            can = false;
        if (FindObjectOfType<PlayerManager>().isPaused)
            can = false;
        if (PlayerManager.isGameOver == true)
            can = false;
        return can;
    }
}
