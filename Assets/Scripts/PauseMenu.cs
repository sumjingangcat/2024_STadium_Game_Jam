using System.Collections;
using System.Collections.Generic;
using Spear;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused;

    [SerializeField] private GameObject pauseWindow;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0;
        pauseWindow.SetActive(true);
        SoundManager.Instance.PauseSoundQueue();
    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1;
        pauseWindow.SetActive(false);
        SoundManager.Instance.ResumeSoundQueue();
    }
}
