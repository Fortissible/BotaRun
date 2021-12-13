using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject levelSelector, settingWindow, creditWindow;

    public void playGame()
    {
        levelSelector.SetActive(true);
    }

    public void openSettings()
    {
        settingWindow.SetActive(true);
    }

    public void closeSettings()
    {
        settingWindow.SetActive(false);
    }

    public void openCredit()
    {
        creditWindow.SetActive(true);
    }

    public void closeCredit()
    {
        creditWindow.SetActive(false);
    }

    public void setFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }


    public void quitGame()
    {
        Application.Quit();
    }

}
