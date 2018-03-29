using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class biomeGod : MonoBehaviour
{
    public static biomeGod singleton;

    //Taxonomy of biomes.
    public enum biomeGenus
    {
        // Level 1.
        L01_grass,
        L01_forestA,
        L01_forestB,
        L01_forestC,
        L01_mountainA,
        L01_mountainB,
        L01_mountainC,

        // Level 2.
        L02_grassA,
        L02_grassB,
        L02_grassC,
        L02_grassD,
        L02_forestA,
        L02_forestB,
        L02_forestC,
        L02_mountainA,
        L02_mountainB,
        L02_mountainStart,
        L02_mountainMiddle,
        L02_mountainEnd,
        L02_waterStart,
        L02_waterMiddleA,
        L02_waterMiddleB,
        L02_waterEnd,
    };

    #region ------- GENE
    public biomeGene biomeVoid;

    //Biome genes. Level 1.
    public biomeGene L01_grass;
    public biomeGene L01_forestA;
    public biomeGene L01_forestB;
    public biomeGene L01_forestC;
    public biomeGene L01_mountainA;
    public biomeGene L01_mountainB;
    public biomeGene L01_mountainC;

    //Biome genes. Level 2.
    public biomeGene L02_grassA;
    public biomeGene L02_grassB;
    public biomeGene L02_grassC;
    public biomeGene L02_grassD;
    public biomeGene L02_forestA;
    public biomeGene L02_forestB;
    public biomeGene L02_forestC;
    public biomeGene L02_mountainA;
    public biomeGene L02_mountainB;
    public biomeGene L02_mountainStart;
    public biomeGene L02_mountainMiddle;
    public biomeGene L02_mountainEnd;
    public biomeGene L02_waterStart;
    public biomeGene L02_waterMiddleA;
    public biomeGene L02_waterMiddleB;
    public biomeGene L02_waterEnd;

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
            // Level 1.
            case biomeGenus.L01_grass:
            return L01_grass;

            case biomeGenus.L01_forestA:
            return L01_forestA;

            case biomeGenus.L01_forestB:
            return L01_forestB;

            case biomeGenus.L01_forestC:
            return L01_forestC;

            case biomeGenus.L01_mountainA:
            return L01_mountainA;

            case biomeGenus.L01_mountainB:
            return L01_mountainB;

            case biomeGenus.L01_mountainC:
            return L01_mountainC;

            // Level 2.
            case biomeGenus.L02_grassA:
            return L02_grassA;

            case biomeGenus.L02_grassB:
            return L02_grassB;

            case biomeGenus.L02_grassC:
            return L02_grassC;

            case biomeGenus.L02_grassD:
            return L02_grassD;

            case biomeGenus.L02_forestA:
            return L02_forestA;

            case biomeGenus.L02_forestB:
            return L02_forestB;

            case biomeGenus.L02_forestC:
            return L02_forestC;

            case biomeGenus.L02_mountainA:
            return L02_mountainA;

            case biomeGenus.L02_mountainB:
            return L02_mountainB;

            case biomeGenus.L02_mountainStart:
            return L02_mountainStart;

            case biomeGenus.L02_mountainMiddle:
            return L02_mountainMiddle;

            case biomeGenus.L02_mountainEnd:
            return L02_mountainEnd;

            case biomeGenus.L02_waterStart:
            return L02_waterStart;

            case biomeGenus.L02_waterMiddleA:
            return L02_waterMiddleA;

            case biomeGenus.L02_waterMiddleB:
            return L02_waterMiddleB;

            case biomeGenus.L02_waterEnd:
            return L02_waterEnd;

            default:
            return biomeVoid;
        }
    }
}
