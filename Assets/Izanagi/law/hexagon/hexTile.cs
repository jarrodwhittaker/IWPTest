using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshCollider), typeof(MeshRenderer))]
public class hexTile : MonoBehaviour
{
    #region------- KEY
    public int token;
    public Vector3 axial;
    #endregion

    #region------- MESH
    public Mesh myMesh;
    public MeshCollider myBound;
    #endregion

    #region------- BIOME
    public biomeGod biome;
    public biomeGod.biomeGenus myGenus;
    public biomeGene myBiome;
    #endregion

    #region------- PATH
    public hexAid.WayGenus myWay;

    // Effort aggregate: cost and known.
    public int aggregate { get; private set; }

    // Effort antecedent: from path origin to tile. 
    public int effort { get; private set; }

    // Effort extant: cost of this tile.
    public int cost { get; private set; }

    // Effort estimated: from tile to destination.
    public int heuristic { get; private set; }

    // My parent.
    public hexTile antecedent { get; private set; }
    #endregion

    #region------- GAME
    public UnitScript myUnit;
    #endregion

    // Executed on object load.
    void Awake()
    {
        
    }

    // Executed ahead of first update.
    void Start()
    {
        DefineBiome();
        DefineCost();

        // When unit extant, pass tile to unit.
        if(myUnit != null)
        {
            myUnit.DefineTile(this);
        }
    }

    // Accessed to define the tile.
    public void DefineTile(hexAid.schematicGenus _schematic, int _token, Vector3 _table, biomeGod.biomeGenus _genus)
    {
        // Define key properties.
        token = _token;
        axial = hexAid.DefineAxial(_schematic, _table);

        // Define default genus.
        myGenus = _genus;

        // Define mesh.
        DefineMesh();
    }

    // Defines the tile mesh.
    void DefineMesh()
    {
        myMesh = GetComponent<MeshFilter>().mesh = new Mesh();
        myMesh.name = "tile: " + token;

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

    // Defines the biome cost.
    public void DefineCost()
    {
        // Define from biome if cost reasonable.
        if(myBiome.cost > 0)
        {
            cost = myBiome.cost;
        }

        else
        {
            // Define cost as 1.
            cost = 1;
        }
    }

    // Defines the path score.
    public void DefineProperties(hexTile _antecedent, int _effort, int _heuristic)
    {
        // Define the antecedent.
        antecedent = _antecedent;

        // Define new score.
        heuristic = _heuristic;
        effort = _effort;

        // Define aggregate.
        aggregate = _effort + cost;
    }

    // Defines the path score.
    public void CleanProperties()
    {
        myWay = hexAid.WayGenus.fog;
        antecedent = null;

        // Define score as 0.
        effort = 0;
        aggregate = 0;
        heuristic = 0;
    }
}