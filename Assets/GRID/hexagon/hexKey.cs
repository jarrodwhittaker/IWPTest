using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct hexKey
{
    public int token { get; private set; }
    public Vector3 axial { get; private set; }

    // Executed to define key.
    public void DefineKey(hexAid.schematicGenus _schematic, int _token, Vector3 _count)
    {
        token = _token;
        axial = DefineAxial(_schematic, _count);
    }

    // Defines axial coordinates from count and schematic. Counter-clockwise axes.
    static Vector3 DefineAxial(hexAid.schematicGenus _schematic, Vector3 _count)
    {
        switch(_schematic)
        {
            case hexAid.schematicGenus.PointTopped:
            {
                // Due to diagonal tessellation: as X-axial increments up the Z-axial, the X-axial is reduced by half of Z-axial.
                _count.x = _count.x - (int)(_count.z / 2);

                // Since 0 = X + Y + Z.
                _count.y = -_count.x - _count.z;

                break;
            }

            case hexAid.schematicGenus.FlatTopped:
            {
                // Due to diagonal tessellation: as Z-axial increments rightwards on the X-axial, the Z-axial is reduced by half of X-axial.
                _count.z = _count.z - (int)(_count.x / 2);

                // Since 0 = X + Y + Z.
                _count.y = -_count.x - _count.z;

                break;
            }
        }

        return _count;
    }

    // Defines axial coordinates as a string for the sign.
    public string DefineSign()
    {
        return "x: " + axial.x.ToString() + "\n" + "y: " + axial.y.ToString() + "\n" + "z: " + axial.z.ToString();
    }
}
