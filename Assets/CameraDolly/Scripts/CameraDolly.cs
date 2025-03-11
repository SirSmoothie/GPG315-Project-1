using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraDolly : MonoBehaviour
{
    [HideInInspector] public GameObject rail1;
    [HideInInspector] public GameObject rail2;
    [HideInInspector] public GameObject rail3;
    [HideInInspector] public GameObject rail4;
    private float noOfPoints = 0.01f;
    public void ActivateDolly(Camera camera)
    {
        if (camera == null) { Debug.Log("WARNING: Camera was not assigned or sent to the CameraDolly."); }
        if (camera.gameObject.GetComponent<CameraDollyController>() == null) { Debug.Log("WARNING: Camera has not been assigned the CameraDollyController script."); }
        camera.gameObject.GetComponent<CameraDollyController>().ActivateDolly(gameObject);
    }

    public void ActivatePOFDolly(Camera camera)
    {
        if (camera == null) { Debug.Log("WARNING: Camera was not assigned or sent to the CameraDolly."); }
        if (camera.gameObject.GetComponent<CameraDollyController>() == null) { Debug.Log("WARNING: Camera has not been assigned the CameraDollyController script."); }
        camera.gameObject.GetComponent<CameraDollyController>().ActivatePointOfFocusDolly(gameObject);
    }

    public Vector3 GetCameraDollyPosition(float cameraTime)
    {
        Vector3 cameraPosition = Mathf.Pow(1 - cameraTime, 3) * rail1.transform.position +
                                 3 * Mathf.Pow(1 - cameraTime, 2) * cameraTime * rail2.transform.position +
                                 3 * (1 - cameraTime) * Mathf.Pow(cameraTime, 2) * rail3.transform.position +
                                 Mathf.Pow(cameraTime, 3) * rail4.transform.position;
        return cameraPosition;
        
    }
    public void NewRailObjects(GameObject tempRail1, GameObject tempRail2, GameObject tempRail3, GameObject tempRail4)
    {
        rail1 = tempRail1;
        rail2 = tempRail2;
        rail3 = tempRail3;
        rail4 = tempRail4;
        
    }
    private Vector3 gizmosPosition;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 gizmosPositionLastPos = new Vector3(rail1.transform.position.x, rail1.transform.position.y, rail1.transform.position.z);
        for (float i = 0; i <= 1; i += noOfPoints)
        {
            gizmosPosition = Mathf.Pow(1 - i, 3) * rail1.transform.position +
                             3 * Mathf.Pow(1 - i, 2) * i * rail2.transform.position +
                             3 * (1 - i) * Mathf.Pow(i, 2) * rail3.transform.position + Mathf.Pow(i,3) * rail4.transform.position;
            
            //Gizmos.DrawSphere(gizmosPosition, sphereThickness);
            Gizmos.DrawLine(gizmosPositionLastPos, gizmosPosition);
            gizmosPositionLastPos = gizmosPosition;
            if (i >= 1)
            {
                Gizmos.DrawLine(gizmosPositionLastPos, rail4.transform.position);
            }
        }
        Gizmos.color = Color.green;
        Gizmos.DrawLine(rail1.transform.position, rail2.transform.position);
        
        Gizmos.DrawLine(rail3.transform.position, rail4.transform.position);
    }
}
