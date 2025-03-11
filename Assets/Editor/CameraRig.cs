using System.Collections;
using UnityEngine;
using UnityEditor;

public class CameraRig : EditorWindow
{
    public Vector3 Position1 = new Vector3(0, 0, 0);
    public Vector3 Position2 = new Vector3(0, 0.5f, 1);
    public Vector3 Position3 = new Vector3(1, 0.5f, 0);
    public Vector3 Position4 = new Vector3(1, 1, 1);
    private string CreateCameraRail = "Create Camera Rail";

    public bool creatingNewRail = true;
    
    [MenuItem("Tools/Camera Rig")] 
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(CameraRig));
    }
    void OnGUI()
    {
        if (GUILayout.Button(CreateCameraRail))
        {
            //if (creatingNewRail)
            //{
                GameObject cameraRail = new GameObject("CameraRailRoute");
                GameObject objToSpawn1 = new GameObject("CameraRail - Start");
                GameObject objToSpawn2 = new GameObject("CameraRail - Point 1");
                GameObject objToSpawn3 = new GameObject("CameraRail - Point 2");
                GameObject objToSpawn4 = new GameObject("CameraRail - End");
                //Instantiate(objToSpawn1, Position1, Quaternion.identity);
                //Instantiate(objToSpawn2, Position2, Quaternion.identity);
                objToSpawn1.transform.position = Position1;
                objToSpawn1.transform.SetParent(cameraRail.transform);
                objToSpawn2.transform.position = Position2;
                objToSpawn2.transform.SetParent(cameraRail.transform);
                objToSpawn3.transform.position = Position3;
                objToSpawn3.transform.SetParent(cameraRail.transform);
                objToSpawn4.transform.position = Position4;
                objToSpawn4.transform.SetParent(cameraRail.transform);
                cameraRail.gameObject.AddComponent<CameraDolly>();
                cameraRail.gameObject.GetComponent<CameraDolly>().NewRailObjects(objToSpawn1, objToSpawn2, objToSpawn3, objToSpawn4);
            //}

        }
        GUILayout.Space(10);
        if (GUILayout.Button("Create CameraRail SemiCircle"))
        {
            
        }
        GUILayout.Space(10);
        if (GUILayout.Button("Create CameraRail Circle"))
        {
            
        }
        GUILayout.Space(10);
        if (GUILayout.Button("Save CameraRail"))
        {
            
        }
        GUILayout.Space(10);
        if (GUILayout.Button("Load CameraRail"))
        {
            
        }
    }
}
