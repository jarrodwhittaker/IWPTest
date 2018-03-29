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

        // Level 3.
        L03_grassA,
        L03_grassB,
        L03_grassC,
        L03_forestA,
        L03_forestB,
        L03_forestC,
        L03_stoneyA,
        L03_stoneyB,
        L03_stoneyC,
        L03_stoneyD,
        L03_lavaStart,
        L03_lavaBendTopLeft,
        L03_lavaBendTopRight,
        L03_lavaBendLeft,
        L03_lavaBendRight,
        L03_lavaMiddleA,
        L03_lavaMiddleB,
        L03_lavaEnd,

        // Level 4.
        L04_iceA,
        L04_iceB,
        L04_iceC,
        L04_iceD,
        L04_forestA,
        L04_forestB,
        L04_forestC,
        L04_forestD,
        L04_mountainA,
        L04_mountainStart,
        L04_mountainMiddleA,
        L04_mountainMiddleB,
        L04_mountainEnd,
        L04_waterStart,
        L04_waterMiddle,
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

    //Biome genes. Level 3.
    public biomeGene L03_grassA;
    public biomeGene L03_grassB;
    public biomeGene L03_grassC;
    public biomeGene L03_stoneyA;
    public biomeGene L03_stoneyB;
    public biomeGene L03_stoneyC;
    public biomeGene L03_stoneyD;
    public biomeGene L03_forestA;
    public biomeGene L03_forestB;
    public biomeGene L03_forestC;
    public biomeGene L03_lavaStart;
    public biomeGene L03_lavaBendTopLeft;
    public biomeGene L03_lavaBendTopRight;
    public biomeGene L03_lavaBendLeft;
    public biomeGene L03_lavaBendRight;
    public biomeGene L03_lavaMiddleA;
    public biomeGene L03_lavaMiddleB;
    public biomeGene L03_lavaEnd;

    // Biome genes. Level 4.
    public biomeGene L04_iceA;
    public biomeGene L04_iceB;
    public biomeGene L04_iceC;
    public biomeGene L04_iceD;
    public biomeGene L04_forestA;
    public biomeGene L04_forestB;
    public biomeGene L04_forestC;
    public biomeGene L04_forestD;
    public biomeGene L04_mountainA;
    public biomeGene L04_mountainStart;
    public biomeGene L04_mountainMiddleA;
    public biomeGene L04_mountainMiddleB;
    public biomeGene L04_mountainEnd;
    public biomeGene L04_waterStart;
    public biomeGene L04_waterMiddle;
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

            // Level 3.
            case biomeGenus.L03_grassA:
            return L03_grassA;

            case biomeGenus.L03_grassB:
            return L03_grassB;

            case biomeGenus.L03_grassC:
            return L03_grassC;

            case biomeGenus.L03_forestA:
            return L03_forestA;

            case biomeGenus.L03_forestB:
            return L03_forestB;

            case biomeGenus.L03_forestC:
            return L03_forestC;

            case biomeGenus.L03_stoneyA:
            return L03_stoneyA;

            case biomeGenus.L03_stoneyB:
            return L03_stoneyB;

            case biomeGenus.L03_stoneyC:
            return L03_stoneyC;

            case biomeGenus.L03_stoneyD:
            return L03_stoneyD;

            case biomeGenus.L03_lavaStart:
            return L03_lavaStart;

            case biomeGenus.L03_lavaBendTopLeft:
            return L03_lavaBendTopLeft;

            case biomeGenus.L03_lavaBendTopRight:
            return L03_lavaBendTopRight;

            case biomeGenus.L03_lavaBendLeft:
            return L03_lavaBendLeft;

            case biomeGenus.L03_lavaBendRight:
            return L03_lavaBendRight;

            case biomeGenus.L03_lavaMiddleA:
            return L03_lavaMiddleA;

            case biomeGenus.L03_lavaMiddleB:
            return L03_lavaMiddleB;

            case biomeGenus.L03_lavaEnd:
            return L03_lavaEnd;

            // Level 4.
            case biomeGenus.L04_iceA:
            return L04_iceA;

            case biomeGenus.L04_iceB:
            return L04_iceB;

            case biomeGenus.L04_iceC:
            return L04_iceC;

            case biomeGenus.L04_iceD:
            return L04_iceD;

            case biomeGenus.L04_forestA:
            return L04_forestA;

            case biomeGenus.L04_forestB:
            return L04_forestB;

            case biomeGenus.L04_forestC:
            return L04_forestC;

            case biomeGenus.L04_forestD:
            return L04_forestD;

            case biomeGenus.L04_mountainA:
            return L04_mountainA;

            case biomeGenus.L04_mountainStart:
            return L04_mountainStart;

            case biomeGenus.L04_mountainMiddleA:
            return L04_mountainMiddleA;

            case biomeGenus.L04_mountainMiddleB:
            return L04_mountainMiddleB;

            case biomeGenus.L04_mountainEnd:
            return L04_mountainEnd;

            case biomeGenus.L04_waterStart:
            return L04_waterStart;

            case biomeGenus.L04_waterMiddle:
            return L04_waterMiddle;

            default:
            return biomeVoid;
        }
    }
}
