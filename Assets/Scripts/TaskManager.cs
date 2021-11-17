using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskManager : MonoBehaviour
{
    public Task task;
    public PlayerManager player;
    public GameObject taskWindow,taskListWindow;
    public TextMeshProUGUI titleText,taskListTitle;
    public TextMeshProUGUI descriptionText;

    public void OpenTaskWindow()
    {
        taskWindow.SetActive(true); 
        titleText.text = task.title;
        taskListTitle.text = "- "+task.desc;
        descriptionText.text = task.desc;
        FindObjectOfType<TimerSettings>().TimerFreeze(true);
    }

    public void AcceptTask()
    {
        taskWindow.SetActive(false);
        taskListWindow.SetActive(true);
        FindObjectOfType<TimerSettings>().TimerFreeze(false);
        task.isActive = true;
        player.task = task;
        task.animator.SetBool("taskCleared", false);
    }
}
