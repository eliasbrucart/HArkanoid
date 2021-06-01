using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager instanceGameManager;

    public int points;

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
    }

    private void Update()
    {
        CheckGameOver();
    }

    private void IncreasePoints()
    {
        points += 10;
    }

    private void OnDisable()
    {
        Ball.AddPoints -= IncreasePoints;
    }
}
