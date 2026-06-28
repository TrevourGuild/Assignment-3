using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDestroyer : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        CanBeHitByBullets canBeHitByBullets = other.GetComponent<CanBeHitByBullets>();
        PlayerShooting playerShooting = other.GetComponent<PlayerShooting>();
        
        if (canBeHitByBullets != null)
        {
            canBeHitByBullets.isHit = true;
        }

        if (playerShooting != null)
        {
            playerShooting.playerSound.clip = playerShooting.shriekSound;
            playerShooting.playerSound.Play();
        }

        Destroy(gameObject);
    }
}
