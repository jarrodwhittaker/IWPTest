using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshCollider), typeof(MeshRenderer))]
public class hexTile : MonoBehaviour
{
    public hexKey myKey;

    #region------- MESH
    public Mesh myMesh;
    public MeshCollider myBound;
    #endregion

    #region------- MESH
    public biomeGod.biomeGenus myGenus;
    public biomeGene myBiome;
    #endregion

    // Executed on object load.
    void Awake()
    {

    }

    // Executed ahead of first update.
    void Start()
    {


    }

    // Accessed to define the tile.
    public void DefineTile(biomeGod.biomeGenus _genus)
    {
        // Define default genus.
        myGenus = _genus;

        // Define mesh.
        DefineMesh();
    }

    // Defines the tile mesh.
    void DefineMesh()
    {
        myMesh = GetComponent<MeshFilter>().mesh = new Mesh();
        myMesh.name = "tile: " + myKey.token;

        // Define allocated mesh properties.
        myMesh.vertices = hexAid.schematicPoints;
        myMesh.triangles = hexAid.schematicVertices;
        myMesh.uv = hexAid.schematicWrap;

        // Define normals and tangents automatically.
        myMesh.RecalculateNormals();
        myMesh.RecalculateTangents();

        // Define the bounds.
        myBound = GetComponent<MeshCollider>();
        myBound.sharedMesh = myMesh;
    }

    // Defines the biome.
    public void DefineBiome()
    {
        // Define biome properties based on tile genus.
        myBiome = biomeGod.singleton.DefineBiome(myGenus);

        // Define a random skin variant.
        Material skin = myBiome.skin;

        // Supply skin to renderer.
        GetComponent<MeshRenderer>().sharedMaterial = skin;
    }
}