using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager instanceGameManager;

    static public GameManager Instance { get { return instanceGameManager; } }

    [SerializeField] private int bricksValue;

    public int score;
    public int highScore { get; set; }
    public SpawnBricks spawnBricks;

    private void Awake()
    {
        if(instanceGameManager != null && instanceGameManager != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instanceGameManager = this;
        }
    }
    private void Start()
    {
        Ball.AddPoints += IncreaseScore;
        Player.IsDead += GameOver;
        highScore = 0;
        highScore = PlayerPrefs.GetInt("highScore");
    }

    private void Update()
    {
        CheckGameOver();
    }

    private void CheckGameOver()
    {
        if (spawnBricks.totalBricks == 0)
            GameOver();
    }

    private void GameOver()
    {
        ScenesManager.instanceScenesManager.ChangeScene("GameOver");
    }

    private void IncreaseScore()
    {
        score += bricksValue;
        if(score > highScore)
        {
            PlayerPrefs.SetInt("highScore", score);
            PlayerPrefs.Save();
        }
    }

    private void OnDisable()
    {
        Ball.AddPoints -= IncreaseScore;
        Player.IsDead -= GameOver;
    }
}
