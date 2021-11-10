using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{
    public Task task;
    public PlayerManager player;

    public GameObject taskWindow;

    public Text titleText;
    public Text descriptionText;
    
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
    }
}
