using System;
using UnityEngine;

public class DestroyBrick : MonoBehaviour
{
    static public event Action DestroyOneBrick;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            Destroy(gameObject);
            DestroyOneBrick?.Invoke();
        }
    }
}
