using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadLevel : MonoBehaviour
{
    public GameObject levelLoadWindow;
    public Slider slider;
    public TextMeshProUGUI progressText;
    public void LevelLoader(string sceneName)
    {
        StartCoroutine(LoadAsync(sceneName));
        levelLoadWindow.SetActive(true);
    }

    IEnumerator LoadAsync(string sceneName)
    {
        AsyncOperation opr = SceneManager.LoadSceneAsync(sceneName);

        while (!opr.isDone)
        {
            float progress = Mathf.Clamp01(opr.progress / .9f);
            slider.value = progress;
            progressText.text = (int)Mathf.Round(progress*100f) + "%";
            Debug.Log(opr.progress);
            yield return null;
        }
    }
}
