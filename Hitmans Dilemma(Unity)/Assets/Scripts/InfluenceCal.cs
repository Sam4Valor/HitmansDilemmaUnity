using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfluenceCal : MonoBehaviour
{

    [Header("Mafia Influence")]

    [Header("IRA")]
    [Range(0, 100)]
    public int IRAInfluence = 100;
    public int IRALevelsDefeated = 0;

    [Header("Italian")]
    [Range(0, 100)]
    public int ItalianInfluence = 100;
    public int ItalianLevelsDefeated = 0;

    [Header("Cartel")]
    [Range(0, 100)]
    public int CartelInfluence = 100;
    public int CartelLevelsDefeated = 0;

    [Header("Yakuza")]
    [Range(0, 100)]
    public int YakuzaInfluence = 100;
    public int YakuzaLevelsDefeated = 0;

    [Header("Russian")]
    [Range(0,100)]
    public int RussianInfluence = 100;
    public int RussianLevelsDefeated = 0;

    // arrays for influence levels

    public int[] MostEffected = new int [6];
    public int[] SecondEffected = new int[6];
    public int[] ThirdEffected = new int[6];
    public int[] LeastEffected = new int[6];


    // Start is called before the first frame update
    void Start()
    {
        MostEffected[0] = 0;
        MostEffected[1] = 8;
        MostEffected[2] = 7;
        MostEffected[3] = 6;
        MostEffected[4] = 8;
        MostEffected[5] = 7;

        SecondEffected[0] = 0;
        SecondEffected[1] = 5;
        SecondEffected[2] = 4;
        SecondEffected[3] = 4;
        SecondEffected[4] = 5;
        SecondEffected[5] = 6;

        ThirdEffected[0] = 0;
        ThirdEffected[1] = 4;
        ThirdEffected[2] = 5;
        ThirdEffected[3] = 5;
        ThirdEffected[4] = 4;
        ThirdEffected[5] = 4;

        LeastEffected[0] = 0;
        LeastEffected[1] = 3;
        LeastEffected[2] = 4;
        LeastEffected[3] = 5;
        LeastEffected[4] = 3;
        LeastEffected[5] = 3;
    }

    public void CalculateInfluence(int Mob, int Deduction)
    {
        // Each level will call this script to edit the data, and refer to this script.
        Mob += Deduction;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
