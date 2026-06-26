using UnityEngine;

public class Kick_Script : MonoBehaviour
{

    public float KickForce = 500f; 
    public float kickRadius = 1.5f; // How wide the kick hitbox is
    
    public Animator playerAnim;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ExecuteKick();
        }
    }

    void ExecuteKick()
    {

        int randomKick = Random.Range(1, 4); 
        playerAnim.SetInteger("KickIndex", randomKick);
        playerAnim.SetTrigger("DoKick");

        Vector3 kickHitboxCenter = transform.position + transform.forward * 1f;
        Collider[] objectsHit = Physics.OverlapSphere(kickHitboxCenter, kickRadius);

        foreach (Collider obj in objectsHit)
        {
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            

            if (rb != null && obj.CompareTag("Kickable"))
            {
                // Pushes the object forward and slightly upward so it flies nicely
                Vector3 kickDirection = (transform.forward + Vector3.up * 0.5f).normalized;
                rb.AddForce(kickDirection * KickForce);
            }
        }
    }
}