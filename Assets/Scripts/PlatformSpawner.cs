using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{

    public static PlatformSpawner instance;

    [SerializeField]
    private GameObject leftPlatform, rightPlatform;

    private float leftXMin = -4.4f;
    private float leftXMax = -2.8f;
    private float rightXMin = 4.4f;
    private float rightXMax = 2.8f;

    private float y_Treshold = 2.6f;
    private float last_Y;

    public int spawnCount = 8;
    private int platformSpawned;

    [SerializeField]
    private Transform platformParent;

    // more variable to spawn birds enemy

    [SerializeField]
    private GameObject bird;

    public float birdY = 5f;
    float birdXMin = -2.3f;
    float birdXMax = 2.3f;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        last_Y = transform.position.y;
        SpawnPlatforms();
    }

    public void SpawnPlatforms()
    {
        Vector2 temp = transform.position;
        GameObject newPlatform = null;

        for (int i = 0; i < spawnCount; i++)
        {
            temp.y = last_Y;

            if((platformSpawned % 2) == 0)
            {
                temp.x = Random.Range(leftXMin, leftXMax);
                newPlatform = Instantiate(leftPlatform, temp, Quaternion.identity);
            }
            else
            {
                temp.x = Random.Range(rightXMin, rightXMax);
                newPlatform = Instantiate(rightPlatform, temp, Quaternion.identity);
            }

            newPlatform.transform.parent = platformParent;

            last_Y += y_Treshold;
            platformSpawned++;
        }

        if(Random.Range(0, 2) > 0)
            SpawnBird();
    }

    void SpawnBird()
    {
        Vector2 temp = transform.position;
        temp.x = Random.Range(birdXMin, birdXMax);
        temp.y += birdY;

        GameObject newBird = Instantiate(bird, temp, Quaternion.identity);
        newBird.transform.parent = platformParent;
    }
}
