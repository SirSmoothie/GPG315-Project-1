using System.Collections;
using UnityEngine;
using UnityEditor;

public class CameraRig : EditorWindow
{
    string[] options = { "None", "Semicircle Dolly", "Sine wave Dolly", "Slide Dolly", "Turn Dolly", "Forward And Back Dolly" };
    int index = 0;
    [MenuItem("Tools/Camera Rig")] 
    static void Init()
    {
        var window = GetWindow<CameraRig>();
        window.position = new Rect(0, 0, 700, 300);
        window.Show();
    }

    void SpawnDolly()
    {
        switch (index)
        {
            case 0:
                Debug.Log("Nothing to Spawn");
                break;
            case 1:
                Object CameraDollySemicircle = AssetDatabase.LoadAssetAtPath("Assets/CameraDolly/CameraDollyBezierCurvePresets/CameraDollySemicircle.prefab", typeof(GameObject));
                Instantiate(CameraDollySemicircle);
                break;
            case 2:
                Object CameraDollySinewave = AssetDatabase.LoadAssetAtPath("Assets/CameraDolly/CameraDollyBezierCurvePresets/CameraDollySinewave.prefab", typeof(GameObject));
                Instantiate(CameraDollySinewave);
                break;
            case 3:
                Object CameraDollySlide = AssetDatabase.LoadAssetAtPath("Assets/CameraDolly/CameraDollyBezierCurvePresets/CameraDollySlide.prefab", typeof(GameObject));
                Instantiate(CameraDollySlide);
                break;
            case 4:
                Object CameraDollyTurn = AssetDatabase.LoadAssetAtPath("Assets/CameraDolly/CameraDollyBezierCurvePresets/CameraDollyTurn.prefab", typeof(GameObject));
                Instantiate(CameraDollyTurn);
                break;
            case 5:
                Object CameraDollyForwardAndBack = AssetDatabase.LoadAssetAtPath("Assets/CameraDolly/CameraDollyBezierCurvePresets/CameraDollyForwardAndBack.prefab", typeof(GameObject));
                Instantiate(CameraDollyForwardAndBack);
                break;
        }
    }
    void OnGUI()
    {
        GUILayout.Space(40);
        index = EditorGUI.Popup(
            new Rect(20, 20, position.width, 40),
            "Spawn Dolly:",
            index,
            options);
        GUILayout.Space(20);
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Spawn Dolly",  GUILayout.Width(400), GUILayout.Height(100)))
        {
            SpawnDolly();
        }
        GUILayout.Space(20);
        
        if (GUILayout.Button("Spawn Example Dolly",GUILayout.Width(200), GUILayout.Height(100)))
        {
            Object DollyExampleSet = AssetDatabase.LoadAssetAtPath("Assets/CameraDolly/CameraDollyBezierCurvePresets/DollyExampleSet.prefab", typeof(GameObject));
            Instantiate(DollyExampleSet);
        }
        GUILayout.EndHorizontal();
        GUILayout.Label("WARNING: Make sure that the other camera is disabled before playing with the Example Dolly.");
        GUILayout.Label("Alternatively Open a new EMPTY scene and then spawn it in.");
    }
}
