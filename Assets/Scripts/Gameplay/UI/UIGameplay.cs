using UnityEngine;
using UnityEngine.UI;

public class UIGameplay : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;
    public Text livesPlayerText;

    public Player player;

    void Update()
    {
        scoreText.text = "Score: " + GameManager.instanceGameManager.score;
        highScoreText.text = "High Score: " + GameManager.instanceGameManager.highScore;
        livesPlayerText.text = "Lives: " + player.lives;
    }
}
