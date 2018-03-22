using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class biomeGene : ScriptableObject
{
    // Movement properties.
    public bool impassable;
    public int cost;

    // Typology of skins.
    public Material skin;
}
