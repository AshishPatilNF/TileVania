using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    [SerializeField]
    int coinValue = 10;

    [SerializeField]
    AudioClip coinPicked;

    GameSession gameSession;

    private void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource.PlayClipAtPoint(coinPicked, Camera.main.transform.position);
        gameSession.AddCoin(coinValue);
        Destroy(this.gameObject);
    }
}
