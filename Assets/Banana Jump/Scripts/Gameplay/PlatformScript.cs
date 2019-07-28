using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{

    [SerializeField]
    private GameObject oneBanana, bananas;

    [SerializeField]
    private Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        GameObject newBanana = null;
        
        if(Random.Range(0, 10) > 3)
        {
            newBanana = Instantiate(oneBanana, spawnPoint.position, Quaternion.identity);
        }
        else
        {
            newBanana = Instantiate(bananas, spawnPoint.position, Quaternion.identity);
        }

        newBanana.transform.parent = transform;
    }
}
