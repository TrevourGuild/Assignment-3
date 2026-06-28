using UnityEngine;
using UnityEngine.Playables;
using Cinemachine;

public class CutsceneSkipper : MonoBehaviour
{
    public PlayableDirector timeline;
    public GameObject playerMovementScriptObject;
    public CinemachineVirtualCamera playerVcam;

    void Start()
    {
        // Player should not move during cutscene
        playerMovementScriptObject.GetComponent<MonoBehaviour>().enabled = false;

        // Player camera starts low priority during cutscene
        playerVcam.Priority = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EndCutscene();
        }
    }

    public void EndCutscene()
    {
        timeline.Stop();

        // Turn on player control
        playerMovementScriptObject.GetComponent<MonoBehaviour>().enabled = true;

        // Make player camera take over
        playerVcam.Priority = 20;
    }
}