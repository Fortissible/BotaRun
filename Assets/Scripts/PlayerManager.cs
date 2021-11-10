using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;

    public Task task;

    public void doingTask()
    {
        if (task.isActive)
        {
            task.goal.ItemGathered();
            if (task.goal.isReached())
            {
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
        }
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
