using UnityEngine;
using System.Collections;

/*
dna reference:
    0 = this will always be either empty or grass
    1 = this will always be filled with either water or trees
    2 = this will have a very high chance of being grass
    3 = this will have a high chance of being grass
    4 = this will have a very high chance of not being grass
*/

public class DNA
{
    public DNA() { }

    public int[,] dnaTable = new int[16, 16]
    {
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 4, 4, 4, 4, 3, 3, 3, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 1, 4, 4, 4, 3, 3, 3, 3, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 1, 4, 4, 3, 3, 3, 3, 3, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 1, 4, 4, 3, 3, 3, 3, 3, 2, 2, 2, 2, 2, 2, 0, 0 },
        { 1, 4, 4, 3, 3, 3, 3, 3, 2, 2, 2, 2, 0, 0, 0, 0 },
        { 1, 4, 4, 3, 3, 3, 3, 3, 2, 2, 0, 0, 0, 0, 0, 0 },
        { 1, 4, 4, 3, 3, 3, 3, 3, 2, 2, 0, 0, 0, 0, 0, 0 },
        { 1, 4, 4, 3, 3, 3, 3, 3, 2, 2, 0, 0, 0, 0, 0, 0 },
        { 1, 4, 4, 3, 3, 3, 3, 3, 2, 2, 0, 0, 0, 0, 0, 0 },
        { 1, 4, 4, 3, 3, 3, 3, 3, 2, 2, 2, 2, 0, 0, 0, 0 },
        { 1, 4, 4, 3, 3, 3, 3, 3, 2, 2, 2, 2, 2, 2, 0, 0 },
        { 1, 4, 4, 3, 3, 3, 3, 3, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 1, 4, 4, 4, 3, 3, 3, 3, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 1, 4, 4, 4, 4, 3, 3, 3, 2, 2, 2, 2, 2, 2, 2, 2 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
    };

    private int[] DNAData(int type)
    {
        /*
              total is always 100
            { water, grass, trees }
        */

        switch (type)
        {
            case 0:
                return new int[3]{ 0, 100, 0 };
            case 1:
                return new int[3] { 50, 0, 50 };
            case 2:
                return new int[3] { 10, 80, 10 };
            case 3:
                return new int[3] { 15, 70, 15 };
            case 4:
                return new int[3] { 40, 20, 40 };
            default:
                return null;
        }
    }

    public int getDNASample (int x, int y)
    {
        var rand = (int)Random.Range(1, 100);
        var dnaString = DNAData(dnaTable[x, y]);

        if (rand <= dnaString[0])
            return 0;
        else if ((rand - dnaString[0]) <= dnaString[1])
            return 1;
        else
            return 2;
    } 
}
