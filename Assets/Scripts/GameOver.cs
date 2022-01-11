using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject boardScreen;

    void Start()
    {
        Player.PlayerDead += OnGameOver;
    }

    void OnDestroy() {
        Player.PlayerDead -= OnGameOver;
    }

    public void OnGameOver() {
        boardScreen.SetActive(false);
        gameOverScreen.SetActive(true);
    }
}
