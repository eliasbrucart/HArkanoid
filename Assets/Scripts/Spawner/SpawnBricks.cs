using UnityEngine;

public class SpawnBricks : MonoBehaviour
{
    [SerializeField] private GameObject greenBrick;
    [SerializeField] private GameObject blueBrick;
    [SerializeField] private GameObject redBrick;
    [SerializeField] private GameObject yellowBrick;
    [SerializeField] private int numberOfBricks;
    [SerializeField] private float initialPosX;
    [SerializeField] private float greenInitialPosZ;
    [SerializeField] private float blueInitialPosZ;
    [SerializeField] private float redInitialPosZ;
    [SerializeField] private float yellowInitialPosZ;
    [SerializeField] private float separationPosX;

    private float brickPosY = 0.5f;
    void Start()
    {
        for(int i = 0; i < numberOfBricks; i++)
        {
            GameObject greenCurrentBrick = Instantiate(greenBrick, transform);
            greenCurrentBrick.transform.position = new Vector3(initialPosX + (separationPosX * i), brickPosY, greenInitialPosZ);
        }

        for (int i = 0; i < numberOfBricks; i++)
        {
            GameObject blueCurrentBrick = Instantiate(blueBrick, transform);
            blueCurrentBrick.transform.position = new Vector3(initialPosX + (separationPosX * i), brickPosY, blueInitialPosZ);
        }

        for (int i = 0; i < numberOfBricks; i++)
        {
            GameObject redCurrentBrick = Instantiate(redBrick, transform);
            redCurrentBrick.transform.position = new Vector3(initialPosX + (separationPosX * i), brickPosY, redInitialPosZ);
        }

        for (int i = 0; i < numberOfBricks; i++)
        {
            GameObject yellowCurrentBrick = Instantiate(yellowBrick, transform);
            yellowCurrentBrick.transform.position = new Vector3(initialPosX + (separationPosX * i), brickPosY, yellowInitialPosZ);
        }
    }
}
