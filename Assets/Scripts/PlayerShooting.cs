using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject prefab;
    public GameObject shootPoint;
    public AudioSource playerSound;
    public AudioClip pistolSound;
    public AudioClip shriekSound;
    private GameObject clone;
    private float shootTimer = 1f;
    private float shootTimerReduction = 1f;

    // Update is called once per frame
    void Update()
    {
        // On key press, spawn a bullet with our player's  rotation and orientation
        if (Input.GetKey(KeyCode.F) && shootTimer <= 0f)
        {
            // Destroy our previous bullet if it is still around
            if (clone != null)
            {
                Destroy(clone);
            }
            clone = Instantiate(prefab);

            clone.transform.position = shootPoint.transform.position;
            clone.transform.forward = shootPoint.transform.forward;
            clone.transform.rotation = shootPoint.transform.rotation;

            shootTimer = 1f;

            playerSound.clip = pistolSound;
            playerSound.Play();

            FindObjectOfType<MusicManager>().PlayerShotGun();
        }
        
        // Only allow 1 bullet to be spawned per second
        if (shootTimer >= 0f)
        {
            shootTimer = shootTimer - (shootTimerReduction * Time.deltaTime);
        }

        // After one second, delete bullet to clear up memory.
        if (shootTimer <= 0f)
        {
            if (clone != null)
            {
                Destroy(clone);
            }
        }
        Debug.Log("" + shootTimer);

       
        
    }
}
