using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanBeHitByBullets : MonoBehaviour
{
    public bool isHit = false;
    Animator animator;
 
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isHit)
        {
            animator.SetBool("isHit", true);
        }
    }
}
