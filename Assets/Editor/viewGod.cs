using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(hexGod))]
public class viewGod : Editor
{
    hexGod origin;

    // Executed on load of object inspector.
    void OnEnable()
    {
        // Grab the origin script.
        origin = (hexGod)target;
    }

    // Executed to override default object inspector.
    public override void OnInspectorGUI()
    {
        // Draw custom inputs.
        GUILayout.Space(7);
        {
            // Generate new grid on button down.
            if(GUILayout.Button("Generate Grid"))
            {
                origin.GenerateGrid();
            }

            // Remove extant grid on button down.
            if(GUILayout.Button("Remove Grid"))
            {
                origin.RemoveGrid();
            }

            // Remove extant grid on button down.
            if(GUILayout.Button("Generate Biome"))
            {
                origin.GenerateBiome();
            }
        }
        GUILayout.Space(7);
        
        // Draw the remaining default variables.
        DrawDefaultInspector();
    }
}
