using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public static bool timerAvailable = true;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "GameOver")
        {
            FindObjectOfType<SoundManager>().Play("RobloxDeathSound");
            Debug.Log("You Died");
            PlayerManager.isGameOver = true;
            gameObject.SetActive(false);
        }
    }
}
