using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera vcamA;
    
    [SerializeField]
    private CinemachineVirtualCamera vcamB;
    
    private bool cameraA = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            SwitchPriority();
        }
    }

    private void SwitchPriority()
    {
        if (cameraA) {
            vcamA.Priority = 0;
            vcamB.Priority = 1;
        } else {
            vcamA.Priority = 1;
            vcamB.Priority = 0;
        }

        cameraA = !cameraA;
    }
}
