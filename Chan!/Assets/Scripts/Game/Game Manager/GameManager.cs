using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : Singleton<GameManager>
{
    public static UnityAction OnPause, OnResume;

    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    /// <summary>
    /// Pauses the game and invokes OnPuase event.
    /// </summary>
    public void PauseGame()
    {
        Time.timeScale = 0f;

        OnPause?.Invoke();
    }

    /// <summary>
    /// Resumes the game and invokes OnResume event.
    /// </summary>
    public void ResumeGame()
    {
        Time.timeScale = 1f;

        OnResume?.Invoke();
    }
}
