using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraDolly : MonoBehaviour
{
    public GameObject rail1;
    public GameObject rail2;
    public GameObject rail3;
    public GameObject rail4;
    public float sphereThickness = 0.1f;
    public float noOfPoints = 0.1f;
    public void ActivateDolly(Camera camera)
    {
        
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
        }
        Gizmos.color = Color.green;
        Gizmos.DrawLine(rail1.transform.position, rail2.transform.position);
        
        Gizmos.DrawLine(rail3.transform.position, rail4.transform.position);
    }
}
