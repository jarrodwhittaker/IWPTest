using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class hexAid
{
    public const int voidToken = -7;
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
        new Vector2(0.5f, 0.99f),
        new Vector2(0.99f, 0.74f),
        new Vector2(0.99f, 0.26f),
        new Vector2(0.5f, 0.01f),
        new Vector2(0.01f, 0.26f),
        new Vector2(0.01f, 0.74f),
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
        new Vector2(0.99f, 0.5f),
        new Vector2(0.74f, 0.01f),
        new Vector2(0.26f, 0.01f),
        new Vector2(0.01f, 0.5f),
        new Vector2(0.26f, 0.99f),
        new Vector2(0.74f, 0.99f),
    };

    #endregion

    #region--------------------------- Key.

    // Defines axial coordinates as a string for the sign.
    public static string DefineSign(Vector3 _axial)
    {
        return "x: " + _axial.x.ToString() + "\n" + "y: " + _axial.y.ToString() + "\n" + "z: " + _axial.z.ToString();
    }

    // Defines axial from table coordinates. Counter-clockwise axes.
    public static Vector3 DefineAxial(schematicGenus _schematic, Vector3 _table)
    {
        switch(_schematic)
        {
            case schematicGenus.PointTopped:
            {
                // Due to diagonal tessellation: as X-axial increments up the Z-axial, the X-axial is reduced by half of Z-axial.
                _table.x = _table.x - (int)(_table.z / 2);

                // Since 0 = X + Y + Z.
                _table.y = -_table.x - _table.z;

                break;
            }

            case schematicGenus.FlatTopped:
            {
                // Due to diagonal tessellation: as Z-axial increments rightwards on the X-axial, the Z-axial is reduced by half of X-axial.
                _table.z = _table.z - (int)(_table.x / 2);

                // Since 0 = X + Y + Z.
                _table.y = -_table.x - _table.z;

                break;
            }
        }

        return _table;
    }

    // Defines table from axial coordinates.
    public static Vector3 DefineTable(schematicGenus _schematic, Vector3 _axial)
    {
        switch(_schematic)
        { 
            case schematicGenus.PointTopped:
            {
                // Prevent division by 0.
                if(_axial.x != 0)
                {
                    // Add the removed X increment. As X-axial incremented up the Z-axial, the X-axial was reduced by half of Z-axial.
                    _axial.x = _axial.x + (int)(_axial.z / 2);
                }

                break;
            }

            case schematicGenus.FlatTopped:
            {
                // Prevent division by 0.
                if(_axial.x != 0)
                {
                    // Add the removed Z increment. As Z-axial incremented rightwards on the X-axial, the Z-axial was reduced by half of X-axial.
                    _axial.z = _axial.z + (int)(_axial.x / 2);
                }

                break;
            }
        }

        return _axial;
    }

    // Defines token from table coordinates.
    public static int DefineToken(schematicGenus _schematic, int _gridX, int _gridZ, Vector3 _table)
    {
        int token = voidToken;

        switch(_schematic)
        {
            case schematicGenus.PointTopped:
            {
                // Z count by no. of X tiles per row. Add excess X on final row.
                token = (int)((_gridX * _table.z) + _table.x);
                break;
            }

            case schematicGenus.FlatTopped:
            {
                // X count by no. of Z tiles per column. Add excess Z on final column.
                token = (int)((_gridZ * _table.x) + _table.z);
                break;
            }
        }

        return token;
    }

    #endregion

    #region--------------------------- Hood.

    // Coordinate difference of each neighbour.
    public static Vector3[] hoodCoordinates =
    {
        new Vector3(0, -1, 1),
        new Vector3(1, -1, 0),
        new Vector3(1, 0, -1),
        new Vector3(0, 1, -1),
        new Vector3(-1, 1, 0),
        new Vector3(-1, 0, 1),
    };

    // Defines the hood for a specified range.
    public static hexTile[] DefineHood(hexTile _origin, int _range, bool _canImpassable)
    {
        // Define empty vicinity and add origin.
        List<hexTile> vicinity = new List<hexTile>();
        vicinity.Add(_origin);

        // Run through the specified range.
        for(int index = 0; index < _range; ++index)
        {
            // Define the extant count.
            int vicinityCount = vicinity.Count;

            // Run through vicinity based on extant count.
            for(int query = 0; query < vicinityCount; ++query)
            {
                // Grab the tile to query.
                hexTile queryTile = vicinity[query];

                // Define each neighbour of queried tile.
                foreach(Vector3 adjustment in hoodCoordinates)
                {
                    // Define axial of neighbour, then convert to table coordinates.
                    Vector3 neighbourTable = DefineTable(hexGod.singleton.schematic, queryTile.axial + adjustment);

                    // Continue if invalid coordinate.
                    if(neighbourTable.x < 0 || neighbourTable.z < 0 || neighbourTable.x >= hexGod.singleton.gridX || neighbourTable.z >= hexGod.singleton.gridZ)
                    {
                        continue;
                    }

                    // Define neighbour based on token from valid table coordinates.
                    hexTile neighbour = hexGod.singleton.grid[DefineToken(hexGod.singleton.schematic, hexGod.singleton.gridX, hexGod.singleton.gridZ, neighbourTable)];

                    // Continue if cannot traverse and tile impassable.
                    if(!_canImpassable && neighbour.myBiome.impassable)
                    {
                        continue;
                    }

                    // Continue if neighbour tile already in vicinity.
                    if(vicinity.Contains(neighbour))
                    {
                        continue;
                    }
                    
                    // Add to vicinity if not invalid.
                    vicinity.Add(neighbour);
                }
            }
        }

        // Remove origin tile from vicinity.
        vicinity.Remove(_origin);

        return vicinity.ToArray();
    }

    #endregion

    #region--------------------------- Path.

    // Taxonomy for A*.
    public enum WayGenus
    {
        open,
        charted,
        fog,
    }

    // Defines path from origin to destination.
    public static hexTile[] DefinePath(hexTile _origin, hexTile _destination, bool _canImpassable)
    {
        // Clean path properties of tiles in grid.
        CleanPath();

        // Define path as not found.
        bool hasPath = false;
        List<hexTile> query = new List<hexTile>();

        // Begin query at origin.
        query.Add(_origin);
        _origin.myWay = WayGenus.open;

        // Find a valid path.
        while(query.Count > 0 && !hasPath)
        {
            // Find a tile to prioritise in the query and define it as charted.
            hexTile priority = DefinePriority(query);
            priority.myWay = WayGenus.charted;

            // Run through hood of priority tile.
            DefineVicinity(ref hasPath, ref query, priority, _destination, _canImpassable);

            // Remove charted tile from query.
            query.Remove(priority);
        }

        // Define path.
        List<hexTile> path = new List<hexTile>();

        // Construct valid path if path extant.
        if(hasPath)
        {
            // Commence step from destination tile.
            hexTile step = _destination;

            // Step backwards while step not origin.
            {
                do
                {
                    path.Add(step);
                    step = step.antecedent;
                }

                while(step != _origin);
            }

            // Add origin tile.
            path.Add(_origin);

            // Reverse the path to commence at origin.
            path.Reverse();
        }

        return path.ToArray();
    }

    // Defines priority tile to query.
    static hexTile DefinePriority(List<hexTile> _query)
    {
        // Begin query by defining optimum as first tile.
        hexTile optimum = _query[0];

        // Run through tiles in query. Heuristic previously defined in DefinePath() while loop.
        for(int index = 0; index < _query.Count; ++index)
        {
            // Define optimum as tile with lowest combined aggregate and heuristic.
            if(_query[index].aggregate + _query[index].heuristic < optimum.aggregate + optimum.heuristic)
            {
                optimum = _query[index];
            }
        
            // Break when tied.
            if(_query[index].aggregate + _query[index].heuristic == optimum.aggregate + optimum.heuristic)
            {
                // Define optimum as tile with lowest combined heuristic and cost.
                if(_query[index].heuristic + _query[index].cost < optimum.heuristic + optimum.cost)
                {
                    optimum = _query[index];
                }
            }
        }

        Debug.Log(optimum);
        return optimum;
    }

    // Define vicinity for pathfind.
    static void DefineVicinity(ref bool _hasPath, ref List<hexTile> _query, hexTile _priority, hexTile _destination, bool _canImpassable)
    {
        // Define vicinity of priority tile.
        hexTile[] vicinity = DefineHood(_priority, 1, _canImpassable);

        // Run through vicinity.
        foreach(hexTile hood in vicinity)
        {
            // Discontinue if destination reached.
            if(hood == _destination)
            {
                // Define tile path properties: priority as antecedent, effort as antencedent's aggregate.
                hood.DefineProperties(_priority, _priority.aggregate, DefineHeuristic(hood, _destination));

                // Define path found.
                _hasPath = true;

                break;
            }

            // Continue if hood tile passable or can pass impassable, and tile is not charted.
            if((!hood.myBiome.impassable || _canImpassable) && hood.myWay != WayGenus.charted)
            {
                // Commence operations based on hood tile wayGenus.
                switch(hood.myWay)
                {
                    case WayGenus.fog:
                    {
                        // Open hood wayGenus and add to query.
                        hood.myWay = WayGenus.open;
                        _query.Add(hood);

                        // Define tile path properties: priority as antecedent, effort as antencedent's aggregate.
                        hood.DefineProperties(_priority, _priority.aggregate, DefineHeuristic(hood, _destination));

                        break;
                    }

                    case WayGenus.open:
                    {
                        // Adjust hood path properties if effort lower from this priority tile.
                        if(_priority.aggregate < hood.effort)
                        {
                            // Define tile path properties: priority as antecedent, effort as antencedent's aggregate.
                            hood.DefineProperties(_priority, _priority.aggregate, DefineHeuristic(hood, _destination));
                        }

                        break;
                    }
                }
            }
        }
    }

    // Defines tile heuristic to destination.
    static int DefineHeuristic(hexTile _origin, hexTile _destination)
    {
        int heuristic = 0;

        // Define table coordinates.
        Vector3 originTable = DefineTable(hexGod.singleton.schematic, _origin.axial);
        Vector3 destinationTable = DefineTable(hexGod.singleton.schematic, _destination.axial);

        switch(hexGod.singleton.schematic)
        {
            case schematicGenus.PointTopped:
            {
                // Define row (X) and column (Z) differences.
                float differenceX = Mathf.Abs(originTable.x - destinationTable.x);
                float differenceZ = Mathf.Abs(originTable.z - destinationTable.z);

                // Define heuristic as X difference if destination on same column.
                if(differenceZ == 0)
                {
                    heuristic = (int)differenceX;
                }

                else
                {
                    // Define heuristic using equation below if path to destination requires both row and column (corner turn) path.
                    if(differenceX >= (differenceZ / 2))
                    {
                        heuristic = (int)(differenceX + (differenceZ / 2));
                    }

                    // Define heuristic as Z difference if destination on aligned column.
                    else
                    {
                        heuristic = (int)differenceZ;
                    }
                }

                break;
            }

            case schematicGenus.FlatTopped:
            {
                // Define row (X) and column (Z) differences.
                float differenceX = Mathf.Abs(originTable.x - destinationTable.x);
                float differenceZ = Mathf.Abs(originTable.z - destinationTable.z);

                // Define heuristic as Z difference if destination on same column.
                if(differenceX == 0)
                {
                    heuristic = (int)differenceZ;
                }

                else
                {
                    // Define heuristic using equation below if path to destination requires both row and column (corner turn) path.
                    if(differenceZ >= (differenceX / 2))
                    {
                        heuristic = (int)(differenceZ + (differenceX / 2));
                    }

                    // Define heuristic as X difference if destination on aligned row.
                    else
                    {
                        heuristic = (int)differenceX;
                    }
                }

                break;
            }
        }

        return heuristic;
    }

    // Cleans path properties of grid tiles.
    static void CleanPath()
    {
        foreach(hexTile tile in hexGod.singleton.grid)
        {
            tile.CleanProperties();
        }
    }

    #endregion
}
