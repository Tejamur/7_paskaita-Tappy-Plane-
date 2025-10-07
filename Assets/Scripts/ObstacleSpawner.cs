using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float cooldown = 3;

    private float lastSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - lastSpawnTime > cooldown)
        {
            lastSpawnTime = Time.time;
            Instantiate(obstaclePrefab);
        }
    }
}
