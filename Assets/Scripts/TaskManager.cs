using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskManager : MonoBehaviour
{
    public Task task;
    public PlayerManager player;
    public GameObject taskWindow;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;

    public void OpenTaskWindow()
    {
        taskWindow.SetActive(true); 
        titleText.text = task.title;
        descriptionText.text = task.desc;
    }

    public void AcceptTask()
    {
        taskWindow.SetActive(false);
        task.isActive = true;
        player.task = task;
        task.animator.SetBool("taskCleared", false);
    }
}
