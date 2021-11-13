using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerSettings : MonoBehaviour
{
    public Text textTimer;
    public float waktu = 100; //01.30
    public bool gameIsActive = true;
    public Animator animator;

    void SetText()
    {
        int menit = Mathf.FloorToInt(waktu / 60); // 01
        int detik = Mathf.FloorToInt(waktu % 60); // 30
        textTimer.text = menit.ToString("00") +":"+ detik.ToString("00");
    }
    float countdown;

    private void Update()
    {
        countdown += Time.deltaTime;
        if (gameIsActive && PlayerManager.isGameOver == false)
        {
            if (countdown >= 1)
            {
                waktu--;
                countdown = 0;
            }
        }

        if (gameIsActive && waktu < 15)
        {
            animator.SetBool("hurryUp", true);
        }

        if (gameIsActive && waktu == 0)
        {
            Debug.Log("Time's Up\nYou're late");
            gameIsActive = false;
            PlayerManager.isGameOver = true;
        }

        SetText();
    }
}
