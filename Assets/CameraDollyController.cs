using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDollyController : MonoBehaviour
{
    public Camera mainCamera;

    private Transform[] cameraRails;
    private int RailToGoOn = 0;
    private float tParam = 0f;
    private float tPOVParam = 0f;
    private Vector3 cameraPosition;
    private float speedModifier = 0.5f;
    private bool coroutineAllowed = true;
    public bool CameraMoving = false;
    public CameraDolly attachedCameraDolly;
    public CameraDolly attachedCameraPointOfFocusDolly;
    
    public float SmoothingFactor = 0.5f;
    private void Start()
    {
        mainCamera = gameObject.GetComponent<Camera>();
    }
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
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, newPos, SmoothingFactor);
            
            Vector3 newPOFPos = attachedCameraPointOfFocusDolly.GetCameraDollyPosition(tParam);
            Vector3 PointOfFocus = Vector3.Lerp(gameObject.transform.position, newPOFPos, SmoothingFactor);
            Vector3 lookdirection = gameObject.transform.position - PointOfFocus;
            gameObject.transform.rotation = Quaternion.LookRotation(-lookdirection);
        }
    }
}
