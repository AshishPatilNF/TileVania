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
            Destroy(this.gameObject);
        else
            DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        currentIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        if (currentIndex != SceneManager.GetActiveScene().buildIndex)
            Destroy(this.gameObject);
    }
}
