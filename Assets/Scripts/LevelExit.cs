using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExit : MonoBehaviour
{
    LevelLoader levelLoading;

    private void OnTriggerExit2D(Collider2D collision)
    {
        levelLoading = FindObjectOfType<LevelLoader>();
        StartCoroutine(ExitLevel());
    }

    IEnumerator ExitLevel()
    {
        Time.timeScale = 0.2f;
        yield return new WaitForSecondsRealtime(3);
        Time.timeScale = 1;
        levelLoading.LoadNextLevel();
    }
}
