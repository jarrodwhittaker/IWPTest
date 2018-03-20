using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class hexAid
{
    public const float radius = 10f;
    public const float apothem = radius * 0.866025404f;

    #region------- SCHEMATIC
    // Taxonomy of schematics.
    public enum schematicGenus
    {
        PointTopped,
        FlatTopped,
    };

    // Elements of schematic.
    public static Vector3[] schematicPoints { get; private set; }
    public static int[] schematicVertices { get; private set; }
    public static Vector2[] schematicWrap { get; private set; }
    #endregion
    
    // Accessed to define grid schematics.
    public static void DefineOrientation(schematicGenus _schematic)
    { 
        switch(_schematic)
        {
            case schematicGenus.PointTopped:
            {
                // Use the point topped schematics.
                schematicPoints = pointPoints;
                schematicVertices = pointVertices;
                schematicWrap = pointWrap;
                break;
            }

            case schematicGenus.FlatTopped:
            {
                // Use the flat topped schematics.
                schematicPoints = flatPoints;
                schematicVertices = flatVertices;
                schematicWrap = flatWrap;
                break;
            }
        };
    }

    #region--------------------------- Point Topped.

    // Point topped. Points on a hexagon.
    static Vector3[] pointPoints =
    {
        // Centre.
        new Vector3(0f, 0f, 0f),

        // Ridges. Clockwise from Top.
        new Vector3(0f, 0f, radius),
        new Vector3(apothem, 0f, 0.5f * radius),
        new Vector3(apothem, 0f, -0.5f * radius),
        new Vector3(0f, 0f, -radius),
        new Vector3(-apothem, 0f, -0.5f * radius),
        new Vector3(-apothem, 0f, 0.5f * radius),
    };

    // Point topped. Triangle vertices aligned to points array.
    static int[] pointVertices =
    {
        0, 1, 2,
        0, 2, 3,
        0, 3, 4,
        0, 4, 5,
        0, 5, 6,
        0, 6, 1,
    };

    // Point topped. Wrap coordinates of each point on array.
    static Vector2[] pointWrap =
    {
        new Vector2(0.5f, 0.5f),
        new Vector2(0.5f, 1.0f),
        new Vector2(1.0f, 0.75f),
        new Vector2(1.0f, 0.25f),
        new Vector2(0.5f, 0.0f),
        new Vector2(0.0f, 0.25f),
        new Vector2(0.0f, 0.75f),
    };

    #endregion

    #region--------------------------- Flat Topped.

    // Flat topped. Points on a hexagon.
    static Vector3[] flatPoints =
    {
        // Centre.
        new Vector3(0f, 0f, 0f),

        // Ridges. Clockwise from Right.
        new Vector3(radius, 0f, 0f),                
        new Vector3(0.5f * radius, 0f, -apothem),    
        new Vector3(0.5f * -radius, 0f, -apothem),  
        new Vector3(-radius, 0f, 0f),              
        new Vector3(0.5f * -radius, 0f, apothem), 
        new Vector3(0.5f * radius, 0f, apothem),
    };

    // Flat topped. Triangle vertices aligned to points array.
    static int[] flatVertices =
    {
        0, 1, 2,
        0, 2, 3,
        0, 3, 4,
        0, 4, 5,
        0, 5, 6,
        0, 6, 1,
    };

    // Flat topped. Wrap coordinates of each point on array.
    static Vector2[] flatWrap =
    {
        new Vector2(0.5f, 0.5f),
        new Vector2(1.0f, 0.5f),
        new Vector2(0.75f, 0.0f),
        new Vector2(0.25f, 0.0f),
        new Vector2(0.0f, 0.5f),
        new Vector2(0.25f, 1.0f),
        new Vector2(0.75f, 1.0f),
    };

    #endregion
}
