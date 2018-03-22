using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class biomeGod : MonoBehaviour
{
    public static biomeGod singleton;

    //Taxonomy of biomes.
    public enum biomeGenus
    {
        plain,
        hill,
        ocean,
    };

    #region ------- GENE
    public biomeGene biomeVoid;

    //Biome genes.
    public biomeGene biomePlain;
    public biomeGene biomeHill;
    public biomeGene biomeOcean;
    #endregion

    // Executed on object load.
    void Awake()
    {
        singleton = this;
    }

    // Accessed to define tile biome.
    public biomeGene DefineBiome(biomeGenus _genus)
    {
        switch(_genus)
        {
            case biomeGenus.plain:
            return biomePlain;

            case biomeGenus.hill:
            return biomeHill;

            case biomeGenus.ocean:
            return biomeOcean;

            default:
            return biomeVoid;
        }
    }
}
