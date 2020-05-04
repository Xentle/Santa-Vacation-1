using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearExtraMoving : MonoBehaviour
{
    public float speed = 0.6f;


    void Update()
    {
        if (transform.position.z < 25)
        {
            transform.Translate(transform.forward * speed * Time.deltaTime);
        }
    }
}
