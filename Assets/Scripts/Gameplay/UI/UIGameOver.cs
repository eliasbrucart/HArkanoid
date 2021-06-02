using UnityEngine;
using UnityEngine.UI;

public class UIGameOver : MonoBehaviour
{
    public Text scoreEarned;
    public Text highScore;

    void Update()
    {
        scoreEarned.text = "Score: " + GameManager.instanceGameManager.score;
        highScore.text = "High Score: " + GameManager.instanceGameManager.highScore;
    }
}
