using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI livesText;

    [SerializeField]
    TextMeshProUGUI scoreText;

    int playerLives = 3;

    int score = 0;

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
        livesText.text = playerLives.ToString();
        scoreText.text = score.ToString();
    }

    public void ReduceLives()
    {
        if (playerLives > 1)
        {
            playerLives--;
            livesText.text = playerLives.ToString();
            FindObjectOfType<LevelLoader>().LoadCurrentScene();
        }
        else
        {
            FindObjectOfType<LevelLoader>().LoadMainMenu();
            Destroy(this.gameObject);
        }
    }

    public void AddCoin(int coin)
    {
        score += coin;
        scoreText.text = score.ToString();
    }
}
