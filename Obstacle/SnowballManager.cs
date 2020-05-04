using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballManager : MonoBehaviour
{
    Vector3 dir;
    public float mapSize;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        dir = Random.insideUnitCircle * (mapSize - 10);
        dir.z = Random.Range(Mathf.Sqrt(Mathf.Pow(mapSize - 10, 2.0f) - Mathf.Pow(dir.x, 2.0f)), -Mathf.Sqrt(Mathf.Pow(mapSize - 10, 2.0f) - Mathf.Pow(dir.x, 2.0f)));
        dir -= transform.position;
        dir.y = 0.0f;
        Vector3.Normalize(dir);
    }

    void Update()
    {
        moveCharacter(dir);
        if (transform.position.x > mapSize + 10 || transform.position.z > mapSize + 10 ||
            transform.position.x < -(mapSize + 10) || transform.position.z < -(mapSize + 10))
            Destroy(this.gameObject);
    }

    void moveCharacter(Vector3 direction)
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}