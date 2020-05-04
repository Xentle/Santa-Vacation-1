using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public float SnowballSpawnTime, CrystalSpawnTime;
    public GameObject snowball;
    public GameObject crystal;
    float deltaSnowballSpawnTime, deltaCrystalSpawnTime;
    public float centerSize, mapSize;
    float x, z;
    Vector3 PosCrystal;

    // Update is called once per frame
    void Update()
    {
        deltaSnowballSpawnTime += Time.deltaTime;
        
        if(deltaSnowballSpawnTime > SnowballSpawnTime)
        {
            deltaSnowballSpawnTime = 0;
            for (int i = 0; i < 3; i++)
            {
                x = Random.Range(mapSize, -mapSize);
                z = Random.Range(1.0f, -1.0f);
                if (z > 0)
                    z = 1.0f;
                else
                    z = -1.0f;
                Instantiate(snowball, new Vector3(x, 1.25f, z * Mathf.Sqrt(Mathf.Pow(mapSize, 2.0f) - Mathf.Pow(x, 2.0f))), Quaternion.identity);
            }
        }

        deltaCrystalSpawnTime += Time.deltaTime;

        if (deltaCrystalSpawnTime > CrystalSpawnTime)
        {
            deltaCrystalSpawnTime = 0;
            while(true)
            {
                PosCrystal = Random.insideUnitCircle * (mapSize - 5.0f);
                PosCrystal.z = Random.Range(Mathf.Sqrt(Mathf.Pow(mapSize - 5.0f, 2.0f) - Mathf.Pow(PosCrystal.x, 2.0f)), -Mathf.Sqrt(Mathf.Pow(mapSize - 10, 2.0f) - Mathf.Pow(PosCrystal.x, 2.0f)));
                if ((Mathf.Pow(PosCrystal.x, 2.0f) + Mathf.Pow(PosCrystal.z, 2.0f)) > Mathf.Pow(centerSize, 2.0f))
                    break;
            }
            
            PosCrystal.y = 0.0f;
            Instantiate(crystal, PosCrystal, Quaternion.identity);
        }
    }
}
