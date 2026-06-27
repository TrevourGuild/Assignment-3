using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TntExplosion : MonoBehaviour
{
    public ParticleSystem explosionEffect;
    public GameObject brokenBarrel;
    private GameObject clone;
    private bool wasTriggered = false;

   void OnTriggerEnter()
    {
        if (!wasTriggered)
        {

            explosionEffect.Play();

            //GetComponent<AudioSource>().Play();
            
            clone = Instantiate(brokenBarrel);
            clone.transform.position = gameObject.transform.position;
            clone.transform.forward = gameObject.transform.forward;
            clone.transform.rotation = gameObject.transform.rotation;
            
            GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
        }
        wasTriggered = true;
    }

    void Update()
    {
        if (explosionEffect == null)
        {
           
           Destroy(gameObject);
        }
    }
}
