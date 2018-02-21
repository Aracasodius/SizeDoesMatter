using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ScoreSystem))]
public class ScoreSystemEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        ScoreSystem targetScript = (ScoreSystem)target;

        GUILayout.Space(10);
        if (GUILayout.Button("Reset Score")) { targetScript.ResetScore(); }
        GUILayout.Space(5);
        if (GUILayout.Button("Reset ALL")) { targetScript.ResetAll(); }
        GUILayout.Space(10);
        if (GUILayout.Button("Add Score")) { targetScript.PickupAdd(); }
        GUILayout.Space(20);
    }
}
