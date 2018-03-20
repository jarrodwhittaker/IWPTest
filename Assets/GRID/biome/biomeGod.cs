using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class biomeGod : MonoBehaviour
{
    public static biomeGod singleton;

    // Taxonomy of biomes.
    public enum biomeGenus
    {
        L1_grassA,
        L1_forestA,
        L1_forestB,
        L1_forestC,
        L1_mountainA,
        L1_mountainB,
        L1_mountainC,
        L2_grassA,
        L2_grassB,
        L2_grassC,
        L2_forestA,
        L2_forestB,
        L2_forestC,
        L2_volcanoA,
        L2_volcanoB,
        L2_volcanoC,
        L2_lavaA,
        L2_lavaB,
        L2_lavaC,
        L2_lavaD,
    };

    #region ------- GENE
    public biomeGene L0_void;

    // Level 01.
    public biomeGene L1_grassA;
    public biomeGene L1_forestA;
    public biomeGene L1_forestB;
    public biomeGene L1_forestC;
    public biomeGene L1_mountainA;
    public biomeGene L1_mountainB;
    public biomeGene L1_mountainC;

    // Level 02.
    public biomeGene L2_grassA;
    public biomeGene L2_grassB;
    public biomeGene L2_grassC;
    public biomeGene L2_forestA;
    public biomeGene L2_forestB;
    public biomeGene L2_forestC;
    public biomeGene L2_volcanoA;
    public biomeGene L2_volcanoB;
    public biomeGene L2_volcanoC;
    public biomeGene L2_lavaA;
    public biomeGene L2_lavaB;
    public biomeGene L2_lavaC;
    public biomeGene L2_lavaD;
    #endregion

    // Executed on object load.
    public void Awake()
    {
        singleton = this;
    }

    // Accessed to define tile biome.
    public biomeGene DefineBiome(biomeGenus _genus)
    {
        switch(_genus)
        {
            case biomeGenus.L1_grassA:
            return L1_grassA;
            
            case biomeGenus.L1_forestA:
            return L1_forestA;

            case biomeGenus.L1_forestB:
            return L1_forestB;

            case biomeGenus.L1_forestC:
            return L1_forestC;

            case biomeGenus.L1_mountainA:
            return L1_mountainA;

            case biomeGenus.L1_mountainB:
            return L1_mountainB;

            case biomeGenus.L1_mountainC:
            return L1_mountainC;

            case biomeGenus.L2_grassA:
            return L2_grassA;

            case biomeGenus.L2_grassB:
            return L2_grassB;

            case biomeGenus.L2_grassC:
            return L2_grassC;

            case biomeGenus.L2_forestA:
            return L2_forestA;

            case biomeGenus.L2_forestB:
            return L2_forestB;

            case biomeGenus.L2_forestC:
            return L2_forestC;

            case biomeGenus.L2_volcanoA:
            return L2_volcanoA;

            case biomeGenus.L2_volcanoB:
            return L2_volcanoB;

            case biomeGenus.L2_volcanoC:
            return L2_volcanoC;

            case biomeGenus.L2_lavaA:
            return L2_lavaA;

            case biomeGenus.L2_lavaB:
            return L2_lavaB;

            case biomeGenus.L2_lavaC:
            return L2_lavaC;

            case biomeGenus.L2_lavaD:
            return L2_lavaD;

            default:
            return L0_void;
        }
    }
}
