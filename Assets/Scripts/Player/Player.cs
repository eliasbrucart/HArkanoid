using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int lives;
    [SerializeField] private Vector3 offsetWithBall;

    private int livesToSubtract = 1;

    private Rigidbody rb;

    private Ball ball;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        ball = FindObjectOfType<Ball>();
        OffsetWithBall();
        Ball.PlayerSubtractLives += SubtractLives;
    }

    private void Update()
    {
        InputPlayer();
        OffsetWithBall();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    private void OffsetWithBall()
    {
        if (!ball.isMoving)
            ball.transform.position = transform.position - offsetWithBall;
    }

    private void MovePlayer()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        rb.velocity = Vector3.right * horizontalInput * speed;
    }

    void InputPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ball.isMoving = true;
        }
    }

    private void SubtractLives()
    {
        lives -= livesToSubtract;
        if (lives <= 0)
            lives = 0;
        Debug.Log("resto una vida! vidas: " + lives);
    }

    private void OnDisable()
    {
        Ball.PlayerSubtractLives -= SubtractLives;
    }
}
