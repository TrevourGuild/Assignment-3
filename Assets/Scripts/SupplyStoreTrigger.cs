using UnityEngine;

public class SupplyStoreTrigger : MonoBehaviour
{
    public MusicManager musicManager;

    // Entering the Box collider
    void OnTriggerEnter(Collider other)
    {
        // Check if the thing that entered is the Player
        if (other.CompareTag("Player"))
        {
            musicManager.SetSupplyStoreState(true);
        }
    }

    // Leaving the box collider
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            musicManager.SetSupplyStoreState(false);
        }
    }
}