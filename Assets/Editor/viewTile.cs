using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(hexTile))]
public class viewTile : Editor
{
    // Executed to override default object inspector.
    public override void OnInspectorGUI()
    {
        GUILayout.Space(7);
        EditorGUILayout.LabelField("Key", EditorStyles.boldLabel);
        EditorGUILayout.IntField("Token", ((hexTile)target).token);
        EditorGUILayout.Vector3Field("Axial", ((hexTile)target).axial);

        GUILayout.Space(7);
        EditorGUILayout.LabelField("Biome", EditorStyles.boldLabel);
        ((hexTile)target).myGenus = (biomeGod.biomeGenus)EditorGUILayout.EnumPopup("Gene", ((hexTile)target).myGenus);

        DrawDefaultInspector();
    }
}
