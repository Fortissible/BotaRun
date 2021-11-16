using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;
    public GameObject timer;
    public Task task;

    public void doingTask(string item_name)
    {
        if (task.isActive)
        {
            task.goal.ItemGathered(item_name);
            if (task.goal.isReached())
            {
                FindObjectOfType<TaskManager>().taskListWindow.SetActive(false);
                task.Clear();
            }
        }
    }



    private void Awake()
    {
        isGameOver = false;
    }

    void Update()
    {
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
            timer.SetActive(false);
        }
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GoTo_MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
