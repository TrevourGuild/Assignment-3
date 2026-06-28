using UnityEngine;
using Cinemachine;

public class CameraToggle : MonoBehaviour
{
    public CinemachineVirtualCamera thirdPersonCam;
    public CinemachineVirtualCamera firstPersonCam;
    public Transform orbitPivot;
    public GameObject characterMesh;

    private bool isFirstPerson = false;

    void Start()
    {
        SwitchToThirdPerson();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            isFirstPerson = !isFirstPerson;

            if (isFirstPerson)
                SwitchToFirstPerson();
            else
                SwitchToThirdPerson();
        }

        if (!isFirstPerson && Input.GetKeyDown(KeyCode.R))
        {
            ResetThirdPersonCamera();
        }
    }

    void SwitchToFirstPerson()
    {
        firstPersonCam.gameObject.SetActive(true);
        thirdPersonCam.gameObject.SetActive(true);

        firstPersonCam.Priority = 100;
        thirdPersonCam.Priority = 1;

        if (characterMesh != null)
            characterMesh.SetActive(false);
    }

    void SwitchToThirdPerson()
    {
        firstPersonCam.gameObject.SetActive(true);
        thirdPersonCam.gameObject.SetActive(true);

        firstPersonCam.Priority = 1;
        thirdPersonCam.Priority = 100;

        if (characterMesh != null)
            characterMesh.SetActive(true);
    }

    void ResetThirdPersonCamera()
    {
        if (orbitPivot != null)
            orbitPivot.localRotation = Quaternion.Euler(10f, 0f, 0f);
    }
}