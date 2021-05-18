using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [SerializeField]
    int playerLives = 3;

    private void Awake()
    {
        if (FindObjectsOfType<GameSession>().Length > 1)
            Destroy(this.gameObject);
        else
            DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ReduceLives()
    {
        if (playerLives > 1)
        {
            playerLives--;
            FindObjectOfType<LevelLoader>().LoadCurrentScene();
        }
        else
        {
            FindObjectOfType<LevelLoader>().LoadMainMenu();
            Destroy(this.gameObject);
        }
    }
}
