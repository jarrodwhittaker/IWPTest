using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class hexGod : MonoBehaviour
{
    public static hexGod singleton;

    #region------- GRID
    public hexAid.schematicGenus schematic;
    public biomeGod.biomeGenus defaultBiome;
    hexTile[] grid;
    public int gridX, gridZ;
    #endregion

    #region------- TILE
    public hexTile tileCell;
    #endregion

    #region------- SIGN
    public Text signCell;
    #endregion

    #region--------------------------- Agenda.

    // Executed on object load.
    void Awake()
    {
        singleton = this;
    }

    #endregion

    #region--------------------------- Grid Generation.

    // Generates the tile grid.
    public void GenerateGrid()
    {
        // Remove the extant grid, if any.
        RemoveGrid();

        // Define the schematic.
        hexAid.DefineOrientation(schematic);

        // Grab parents for heirarchy.
        Transform gridPop = GameObject.FindGameObjectWithTag("Grid").transform;
        Transform signPop = GameObject.FindGameObjectWithTag("Map").transform;

        // Generate grid based on input size.
        grid = new hexTile[gridX * gridZ];
        
        // Generate tiles based on schematic.
        switch(schematic)
        {
            case hexAid.schematicGenus.PointTopped:
            {
                // Generate tiles Z up then X left.
                for(int countZ = 0, token = 0; countZ < gridZ; ++countZ)
                {
                    for(int countX = 0; countX < gridX; ++countX, ++token)
                    {
                        GenerateTile(gridPop, signPop, token, countX, countZ);
                    }
                }

                break;
            }

            case hexAid.schematicGenus.FlatTopped:
            {
                // Generate tiles X up then Z left.
                for(int countX = 0, token = 0; countX < gridX; ++countX)
                {
                    for(int countZ = 0; countZ < gridZ; ++countZ, ++token)
                    {
                        GenerateTile(gridPop, signPop, token, countX, countZ);
                    }
                }

                break;
            }
        }
    }

    // Generates each tile of the grid.
    void GenerateTile(Transform _gridPop, Transform _signPop, int _token, int _countX, int _countZ)
    {
        // Generate tile and define heirarchy properties.
        hexTile tile = grid[_token] = Instantiate(tileCell);
        {
            tile.transform.SetParent(_gridPop, false);
            tile.name = "tile: " + _token;
        }

        // Define coordinate position on world space based on schematic.
        Vector3 coordinate = Vector3.zero;
        {
            switch(schematic)
            {
                case hexAid.schematicGenus.PointTopped:
                {
                    // Tessellate by multiplying apothem (X) and radius (Z) to scale with hexagon shape.
                    // Add half an X to offset odd rows. 
                    coordinate.x = (_countX + (_countZ % 2) * 0.5f) * (hexAid.apothem * 2f);
                    coordinate.y = 0f;
                    coordinate.z = _countZ * (hexAid.radius * 1.5f);

                    // Define coordinate.
                    tile.transform.localPosition = coordinate;
                    break;
                } 

                case hexAid.schematicGenus.FlatTopped:
                {
                    // Tessellate by multiplying radius (X) and apothem (Z) to scale with hexagon shape.
                    // Add half a Z to offset odd columns. 
                    coordinate.x = _countX * (hexAid.radius * 1.5f);
                    coordinate.y = 0f;
                    coordinate.z =  (_countZ + (_countX % 2) * 0.5f) * (hexAid.apothem * 2);

                    // Define coordinate.
                    tile.transform.localPosition = coordinate;
                    break;
                } 
            }
        }

        // Define key properties
        {
            Vector3 count = new Vector3(_countX, 0, _countZ);
            tile.myKey.DefineKey(schematic, _token, count);
        }

        // Define internal tile properties.
        tile.DefineTile(defaultBiome);

        // Generate sign and define properties.
        Text sign = Instantiate(signCell);
        {
            // Define heirarchy properties.
            sign.rectTransform.SetParent(_signPop, false);
            sign.name = "sign: " + _token;

            // Define position and content.
            sign.rectTransform.anchoredPosition = new Vector2(coordinate.x, coordinate.z);
            sign.text = tile.myKey.DefineSign();
        }
    }

    // Removes the existing grid and sign map.
    public void RemoveGrid()
    {
        // Remove the grid. Safer method than removing directly from array. 
        grid = new hexTile[0];
        {
            // Grab tiles from Grid parent.
            Transform gridPop = GameObject.FindGameObjectWithTag("Grid").transform;
            Transform[] tiles = gridPop.GetComponentsInChildren<Transform>();

            // Destroy each tile from index 1 because 0 is the parent (gridPop).
            for(int tile = 1; tile < tiles.Length; ++tile)
            {
                DestroyImmediate(tiles[tile].gameObject);
            }
        }

        // Remove the Map.
        {
            // Grab signs from Map parent.
            Transform signPop = GameObject.FindGameObjectWithTag("Map").transform;
            Transform[] signs = signPop.GetComponentsInChildren<Transform>();

            // Destroy each tile from index 1 because 0 is the parent (signPop).
            for(int sign = 1; sign < signs.Length; ++sign)
            {
                DestroyImmediate(signs[sign].gameObject);
            }
        }
    }

    #endregion

    #region--------------------------- Biome Generation.

    // Accessed to generate tile biomes.
    public void GenerateBiome()
    {
        // Grab tiles from Grid parent.
        Transform gridPop = GameObject.FindGameObjectWithTag("Grid").transform;
        hexTile[] tiles = gridPop.GetComponentsInChildren<hexTile>();

        // Define biome for each tile from index 1 because 0 is the parent (gridPop).
        for(int tile = 0; tile < tiles.Length; ++tile)
        {
            tiles[tile].DefineBiome();
        }
    }

    #endregion

    #region--------------------------- Mobility.

    // Which tiles can I go to? Flat topped.
    public void QueryRange()
    {
        switch(schematic)
        {
            case hexAid.schematicGenus.FlatTopped:
            {
                break;
            }
        }
    }

    // What path is best? Flat topped.
    public void QueryPath()
    {
        switch(schematic)
        {
            case hexAid.schematicGenus.FlatTopped:
            {
                break;
            }
        }
    }

    // Which tile is priority? Flat topped.
    public void QueryPriority()
    {
        switch(schematic)
        {
            case hexAid.schematicGenus.FlatTopped:
            {
                break;
            }
        }
    }

    #endregion
}