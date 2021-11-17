using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject levelSelector;

    public void playGame()
    {
        levelSelector.SetActive(true);
    }

    public void quitGame()
    {
        Application.Quit();
    }

}
