using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(hexTile))]
public class viewTile : Editor
{
    int token;
    Vector3 axial;

    // Executed on load of object inspector.
    void OnEnable()
    {
        // Define properties to display.
        token = ((hexTile)target).myKey.token;
        axial = ((hexTile)target).myKey.axial;
    }

    // Executed to override default object inspector.
    public override void OnInspectorGUI()
    {
        GUILayout.Space(7);
        EditorGUILayout.LabelField("Key", EditorStyles.boldLabel);
        EditorGUILayout.IntField("Token", token);
        EditorGUILayout.Vector3Field("Axial", axial);

        DrawDefaultInspector();
    }
}
