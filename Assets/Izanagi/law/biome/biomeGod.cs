using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class biomeGod : MonoBehaviour
{
    public static biomeGod singleton;

    //Taxonomy of biomes.
    public enum biomeGenus
    {
        grass,
        forestA,
        forestB,
        forestC,
        mountainA,
        mountainB,
        mountainC,
    };

    #region ------- GENE
    public biomeGene biomeVoid;

    //Biome genes.
    public biomeGene biomeGrass;
    public biomeGene biomeForestA;
    public biomeGene biomeForestB;
    public biomeGene biomeForestC;
    public biomeGene biomeMountainA;
    public biomeGene biomeMountainB;
    public biomeGene biomeMountainC;
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
            case biomeGenus.grass:
            return biomeGrass;

            case biomeGenus.forestA:
            return biomeForestA;

            case biomeGenus.forestB:
            return biomeForestB;

            case biomeGenus.forestC:
            return biomeForestC;

            case biomeGenus.mountainA:
            return biomeMountainA;

            case biomeGenus.mountainB:
            return biomeMountainB;

            case biomeGenus.mountainC:
            return biomeMountainC;

            default:
            return biomeVoid;
        }
    }
}
