using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject gameWonScreen;
    public GameObject boardScreen;

    bool gameLost;

    void Start()
    {
        Player.PlayerDead += OnGameLost;
        Board.GameWon += OnGameWon;
    }

    void OnDestroy() {
        Player.PlayerDead -= OnGameLost;
        Board.GameWon -= OnGameWon;
    }

    public void OnGameLost() {
        gameLost = true;
        boardScreen.SetActive(false);
        gameOverScreen.SetActive(true);
    }

    public void OnGameWon() {
        if (!gameLost) {
            boardScreen.SetActive(false);
            gameWonScreen.SetActive(true);   
        }
    }
}
