using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    int currentIndex;

    void Start()
    {
        currentIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(currentIndex + 1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    public void LoadCurrentScene()
    {
        SceneManager.LoadScene(currentIndex);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            Application.Quit();
    }
}
