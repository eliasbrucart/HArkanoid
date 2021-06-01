using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager instanceGameManager;

    static public GameManager Instance { get { return instanceGameManager; } }

    [SerializeField] private int bricksValue;

    public int points;
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
        Ball.AddPoints += IncreasePoints;
        Player.IsDead += GameOver;
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

    private void IncreasePoints()
    {
        points += bricksValue;
    }

    private void OnDisable()
    {
        Ball.AddPoints -= IncreasePoints;
        Player.IsDead -= GameOver;
    }
}
