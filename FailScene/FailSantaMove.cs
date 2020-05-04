using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailSantaMove : MonoBehaviour
{
    private Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();

        animator.SetBool("isBasePoint", false);
    }


    void Update()
    {
        if (transform.position.x <= 1.5f)
        {
            animator.SetBool("isBasePoint", true);
        }
    }
}
