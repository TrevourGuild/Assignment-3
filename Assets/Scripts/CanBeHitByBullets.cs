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

            //GetComponent<AudioSource>().Play();

            int random = Random.Range(0, 100);
            if (random >= 50)
            {
                animator.SetBool("death1", true);
            }
            else
            {
                animator.SetBool("death1", false);
            }
        }
    }
}
