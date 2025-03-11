using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDollyTest : MonoBehaviour
{
    public CameraDolly cameraDolly;
    public Camera cameraDollyController;
    public CameraDolly cameraFocus;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (cameraDollyController == null)
            {
                Debug.Log("Camera Dolly Controller was not set as an instance of an Object (Attach the Camera Dolly Controller script to the camera that you want to move and set it as a refrence in this script.)");
                return;
            }
            if (cameraDolly == null)
            {
                Debug.Log("Camera Dolly was not set as an instance of an Object (Spawn in a Camera dolly in Tools, Camera Rig)");
            return;}
            if (cameraFocus == null)
            {
                Debug.Log("Camera Focus Dolly was not set as an instance of an Object (Spawn in a Camera dolly in Tools, Camera Rig)");
                return;}
            cameraDolly.ActivateDolly(cameraDollyController);
            cameraFocus.ActivatePOFDolly(cameraDollyController);
        }
    }
}
