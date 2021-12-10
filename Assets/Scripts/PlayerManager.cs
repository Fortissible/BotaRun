using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public bool isPaused;
    public GameObject gameOverScreen,pauseWindow;
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
    public void doingTaskActivities(string item_name)
    {
        if (task.isActive)
        {
            task.goal.ActivitiesCleared(item_name);
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
        if (Input.GetButtonDown("Cancel"))
        {
            pauseWindow.SetActive(true);
            timer.SetActive(false);
            isPaused = true;
        }
    }

    public void ContinueLevel()
    {
        pauseWindow.SetActive(false);
        timer.SetActive(true);
        isPaused = false;
    }
    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GoTo_MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void GoTo_NextLevel(string name)
    {
        FindObjectOfType<LoadLevel>().LevelLoader(name);
    }
}
