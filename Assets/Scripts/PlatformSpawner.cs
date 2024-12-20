using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;
    public GameObject diamond;
    public static PlatformSpawner instance;
    Vector3 lastPos;
    Vector3 pos;
    float size;
    public bool gameOver;
    Vector3 diamondSpawnPoint;

    [SerializeField]
    float diamondSpawnChance = 0.2f; // 20% chance to spawn a diamond

    // Start is called before the first frame update
    void Start()
    {
        lastPos = platform.transform.position;
        size = platform.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameOver == true)
        {
            CancelInvoke("SpawnPlatforms");
        }

        if(instance == null)
        {
            instance = this;
        }
    }

    public void StartSpawningPlatforms()
    {
        InvokeRepeating("SpawnPlatforms", 0.6f, 0.1f);

    }

    void SpawnX()
    {
        pos = lastPos;
        size = platform.transform.localScale.x; // Update size dynamically
        pos.x += size;
        lastPos = pos;
        Instantiate(platform, pos, Quaternion.identity);
    }

    void SpawnZ()
    {
        pos = lastPos;
        size = platform.transform.localScale.x;
        pos.z += size;
        lastPos = pos;
        Instantiate(platform, pos, Quaternion.identity);
    }

    void SpawnPlatforms()
    {
        int rand = Random.Range(0, 10);

        if (rand < 5)
        {
            SpawnX();
        }
        else
        {
            SpawnZ();
        }

        // Check if a diamond should be spawned
        if (Random.value < diamondSpawnChance)
        {
            SpawnDiamond();
        }
    }

    void SpawnDiamond()
    {
        Vector3 diamondSpawnPoint = pos;
        diamondSpawnPoint.y += 0.52f;
        Instantiate(diamond, diamondSpawnPoint, Quaternion.identity);
    }
}
