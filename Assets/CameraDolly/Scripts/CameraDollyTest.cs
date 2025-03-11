using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDollyTest : MonoBehaviour
{
    public CameraDolly cameraDolly;
    //This is for the Dolly/Rail that the camera would go from start to finish on
    public Camera cameraDollyController;
    // this is the camera that gets forced onto the dolly/rail line.
    public CameraDolly cameraFocus;
    //This is OPTIONAL but... if you want the camera to look at a certain path then this is used to set which path it looks at (Its the same script as the normal path but its activated differently)
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (cameraDollyController == null) //Checks to see once the correct conditions have been met if the cameraDollyController is set to an instance of an object.
            { Debug.Log("Camera Dolly Controller was not set as an instance of an Object (Attach the Camera Dolly Controller script to the camera that you want to move and set it as a refrence in this script.)"); return; }
            if (cameraDolly == null) //Checks to see once the correct conditions have been met if the cameraDolly is set to an instance of an object.
            { Debug.Log("Camera Dolly was not set as an instance of an Object (Spawn in a Camera dolly in Tools, Camera Rig)"); return;}
            if (cameraFocus == null) //Checks to see once the correct conditions have been met if the cameraFocus is set to an instance of an object.
            { Debug.Log("Camera Focus Dolly was not set as an instance of an Object (Spawn in a Camera dolly in Tools, Camera Rig)"); return;}
            
            //To activate the Rail you need to call this public function and pass through the Camera, which in this case is cameraDollyController
            cameraDolly.ActivateDolly(cameraDollyController);
            //To activate the Rail your camera will look at you need to call this public function and pass through the Camera, which in this case is cameraDollyController
            cameraFocus.ActivatePOFDolly(cameraDollyController);
            //btw POF was just short for Point of Focus
        }
    }
}
