using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailSnowPlaneMoving : MonoBehaviour
{
    public float speed = 0.05f;
    public GameObject santa;

    void Update()
    {
        if(this.transform.position.y<=1.0f && santa.transform.position.x<0.75f)
        {
            transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        }
    }
}
