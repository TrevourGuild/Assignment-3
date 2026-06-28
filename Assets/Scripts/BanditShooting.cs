using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditShooting : MonoBehaviour
{
    public GameObject prefab;
    public GameObject shootPoint;
    public AudioSource banditSound;
    public AudioClip pistolSound;
    public AudioClip shriekSound;
    public Transform target;
    public float Min_Angle = -45;
    public float Max_Angle = 45;
    public int bulletFrequencyMin = 2;
    public int bulletFrequencyMax = 10;
    private GameObject clone;
    private float shootTimer = 1f;
    private float shootTimerReduction = 1f;
    private float randomDirection;
    private bool hasDied = false;
    Animator animator;
    
 
    private void Awake()
    {
        animator = GetComponent<Animator>();
        shootTimer = Random.Range(10, 30);
    }

    // Update is called once per frame
    void Update()
    {

        // After our timer is up, delete bullet to clear up memory.
        if (shootTimer <= 0f)
        {
            if (clone != null)
            {
                Destroy(clone);
            }
        }

        // On key press, spawn a bullet with our player's  rotation and orientation
        if (shootTimer <= 0f && !animator.GetBool("isHit"))
        {
            clone = Instantiate(prefab);
            
            
            banditSound.clip = pistolSound;
            banditSound.Play();

            clone.transform.position = shootPoint.transform.position;
            clone.transform.forward = shootPoint.transform.forward;
            //clone.transform.rotation = shootPoint.transform.rotation;

            // Randomize the direction of the bullet so that our outlaws are not 100% accurate every time.
            randomDirection = Random.Range(Min_Angle, Max_Angle);
            clone.transform.rotation = shootPoint.transform.rotation * Quaternion.Euler(0f, randomDirection, 0f);

            shootTimer = Random.Range(bulletFrequencyMin, bulletFrequencyMax);

        }
        
        if (!animator.GetBool("isHit"))
        {
            transform.LookAt(target);
        }

        // Only allow 1 bullet to be spawned at a time, every 30 - 60 seconds
        if (shootTimer >= 0f)
        {
            shootTimer = shootTimer - (shootTimerReduction * Time.deltaTime);
        }

        if (animator.GetBool("isHit") && !hasDied)
        {
            banditSound.clip = shriekSound;
            banditSound.Play();
            hasDied = true;
        }

       
        
    }
}
