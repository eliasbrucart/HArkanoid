using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector3 initialPosition;
    public bool isMoving;
    private float minPos = -11.0f;
    private Vector3 direction;

    static public event Action PlayerSubtractLives;
    void Start()
    {
        isMoving = false;
        direction = transform.forward;
    }

    void Update()
    {
        MoveBall();
        ResetBallPosition();
    }

    void MoveBall()
    {
        if (isMoving)
        {
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "border_top" || collision.gameObject.tag == "border_left" || collision.gameObject.tag == "border_right"
            || collision.gameObject.tag == "blue_brick" || collision.gameObject.tag == "green_brick" || collision.gameObject.tag == "red_brick" || 
            collision.gameObject.tag == "yellow_brick")
                direction *= -1;
        if(collision.gameObject.CompareTag("racket"))
        {
            float x = HitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.x);

            Vector3 newDirection = new Vector3(x, 0, 1).normalized;

            direction = newDirection;

        }
    }

    float HitFactor(Vector3 ballPos, Vector3 racketPos, float racketWidth)
    {
        return (ballPos.x - racketPos.x) / racketWidth;
    }

    void ResetBallPosition()
    {
        if(transform.position.z <= minPos && isMoving)
        {
            transform.position = initialPosition;
            isMoving = false;
            PlayerSubtractLives?.Invoke();
        }
    }
}
