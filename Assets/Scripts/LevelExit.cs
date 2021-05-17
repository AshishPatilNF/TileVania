using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        StartCoroutine(ExitLevel());
    }

    IEnumerator ExitLevel()
    {
        Time.timeScale = 0.2f;
        yield return new WaitForSecondsRealtime(3);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
