using UnityEngine;

public class SpawnBricks : MonoBehaviour
{
    [SerializeField] private GameObject brick;
    [SerializeField] private int numberOfBlocks;
    [SerializeField] private int initialPosX;
    [SerializeField] private int initialPosY;
    [SerializeField] private int separationPosX;
    void Start()
    {
        for(int i = 0; i < numberOfBlocks; i++)
        {
            GameObject currentBrick = Instantiate(brick, transform);
            currentBrick.transform.position = new Vector2(initialPosX + (separationPosX * i), initialPosY);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
