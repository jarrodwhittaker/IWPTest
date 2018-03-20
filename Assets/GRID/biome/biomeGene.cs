using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class biomeGene : ScriptableObject
{
    // True if impassable.
    public bool impassable;

    // Typology of skins.
    public Material skin;
}
