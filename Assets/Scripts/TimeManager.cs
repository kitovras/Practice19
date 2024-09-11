using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    public void InteractWithPauseMenu()
    {
        if (pauseMenu.activeSelf)
        {
            pauseMenu.SetActive(false);
            PlayTime();
        }
        else
        {
            pauseMenu.SetActive(true);
            PauseTime();
        }
    }

    private void PauseTime()
    {
        Time.timeScale = 0.0f;
    }

    private void PlayTime()
    {
        Time.timeScale = 1.0f;
    }

    public void ChangeTime(float time)
    {
        Time.timeScale = time;
    }
}
