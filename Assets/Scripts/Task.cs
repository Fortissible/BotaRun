using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] 
public class Task
{
    public TaskGoals goal;
    public bool isActive;
    public bool isCleared = false;

    public Animator animator;
    public string title;
    public string desc;
    
    public void Clear()
    {
        isActive = false;
        isCleared = true;
        Debug.Log(title + " is cleared!!");
        animator.SetBool("taskCleared", true);
    }
}
