using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSession : MonoBehaviour
{
    int currentIndex;

    private void Awake()
    {
        if (FindObjectsOfType<LevelSession>().Length > 1)
        {
            gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
        else
            DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        currentIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        if (currentIndex != SceneManager.GetActiveScene().buildIndex)
        {
            gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }
}
