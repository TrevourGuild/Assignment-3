using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDestroyer : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        CanBeHitByBullets canBeHitByBullets = other.GetComponent<CanBeHitByBullets>();
        
        if (canBeHitByBullets != null)
        {
            canBeHitByBullets.isHit = true;
        }

        Destroy(gameObject);
    }
}
