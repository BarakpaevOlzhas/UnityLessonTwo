using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {

    [SerializeField]
    private GameOverPanel gameOverPanel;

    [SerializeField]
    private WinPanel winPanel;

    [SerializeField]
	private Text scoreText;

	[SerializeField]
	private Player player;

    private bool isGo = true;

    private float score = 0;
	private void Update() {	

        if (player.transform.position.y > -10 || isGo) {
            score = player.transform.position.z;

            scoreText.text = score.ToString("0");
        }
	}

    private void Start()
    {
        player.onGameOver += GameOver;
        player.onGameWin += GameWin;
    }

    private void GameWin()
    {
        var bestScore = PlayerPrefs.GetFloat("Score");

        isGo = false;

        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetFloat("Score", bestScore);
        }

        winPanel.Init("You Win!",score, bestScore);
    }

    private void GameOver()
    {
        var bestScore = PlayerPrefs.GetFloat("Score");

        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetFloat("Score", bestScore);
        }

        winPanel.Init("Game Over!", score, bestScore);
    }
}
