using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Health))]
public class HealthEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        Health targetScript = (Health)target;

        if (GUILayout.Button("Kill")) { targetScript.Damage(100); }
    }

}
