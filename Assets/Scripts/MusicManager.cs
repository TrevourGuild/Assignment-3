using System.Collections;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource defaultMusic;
    public AudioSource suspenseMusic;
    public AudioSource fightMusic;
    
    private AudioSource currentTrack;
    private float combatTimer = 0f;
    private bool inSupplyStore = false;

    void Start()
    {
        currentTrack = defaultMusic;
        defaultMusic.Play();
        suspenseMusic.Play();
        fightMusic.Play();
    }

    void Update()
    {
        // Combat timer counts down to prevent rapid switching
        if (combatTimer > 0)
        {
            combatTimer -= Time.deltaTime;
            SwitchTrack(fightMusic);
        }
        else if (inSupplyStore)
        {
            SwitchTrack(suspenseMusic);
        }
        else
        {
            SwitchTrack(defaultMusic);
        }
    }

    // Called by the Player's shooting script
    public void PlayerShotGun()
    {
        // If we are not currently in a fight, rewind the song to the beginning
        if (currentTrack != fightMusic)
        {
            fightMusic.time = 0f; 
        }
        
        combatTimer = 5f; // Fight music stays locked in for 5 seconds after the last shot
    }

    // Called by a Trigger Box on the Supply Store
    public void SetSupplyStoreState(bool state)
    {
        inSupplyStore = state;

        // If the player just walked IN, and the suspense music isn't already playing, rewind it!
        if (state == true && currentTrack != suspenseMusic)
        {
            suspenseMusic.time = 0f;
        }
        
        // (Optional) If you also want the Default town music to start from the beginning 
        // when you walk OUT of the store, uncomment the lines below:
        
        /*
        if (state == false && currentTrack != defaultMusic)
        {
            defaultMusic.time = 0f;
        }
        */
    }

    // Smoothly crossfades to the target track
    void SwitchTrack(AudioSource newTrack)
    {
        if (currentTrack == newTrack) return;

        StartCoroutine(FadeOut(currentTrack));
        StartCoroutine(FadeIn(newTrack));
        currentTrack = newTrack;
    }

    IEnumerator FadeIn(AudioSource track)
    {
        while (track.volume < 1f)
        {
            track.volume += Time.deltaTime; // Adjust speed by multiplying Time.deltaTime
            yield return null;
        }
    }

    IEnumerator FadeOut(AudioSource track)
    {
        while (track.volume > 0f)
        {
            track.volume -= Time.deltaTime;
            yield return null;
        }
    }
}