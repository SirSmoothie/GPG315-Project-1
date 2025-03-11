using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDollyController : MonoBehaviour
{
    private int RailToGoOn = 0;
    private float tParam;
    private float tPOVParam;
    public float speedModifier = 0.5f;
    private bool CameraMoving;
    private CameraDolly attachedCameraDolly;
    private CameraDolly attachedCameraPointOfFocusDolly;
    private float smoothingFactor = 0.5f;
    public void ActivateDolly(GameObject dolly)
    {
        attachedCameraDolly = dolly.GetComponent<CameraDolly>();
        tParam = 0f;
        CameraMoving = true;
    }

    public void ActivatePointOfFocusDolly(GameObject dolly)
    {
        attachedCameraPointOfFocusDolly = dolly.GetComponent<CameraDolly>();
        tPOVParam = 0f;
        CameraMoving = true;
    }

    private void Update()
    {
        if (CameraMoving && tParam < 1f)
        {
            tParam += Time.deltaTime * speedModifier;
            Vector3 newPos = attachedCameraDolly.GetCameraDollyPosition(tParam);
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, newPos, smoothingFactor);
            
            Vector3 newPOFPos = attachedCameraPointOfFocusDolly.GetCameraDollyPosition(tParam);
            Vector3 PointOfFocus = Vector3.Lerp(gameObject.transform.position, newPOFPos, smoothingFactor);
            Vector3 lookdirection = gameObject.transform.position - PointOfFocus;
            gameObject.transform.rotation = Quaternion.LookRotation(-lookdirection);
        }
    }
}
