using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfluenceCal : MonoBehaviour
{

    [Header("Mafia Influence")]

    [Header("IRA")]
    [Range(0, 150)]
    public int IRAInfluence = 100;
    public int IRALevelsDefeated = 0;

    [Header("Italian")]
    [Range(0, 150)]
    public int ItalianInfluence = 100;
    public int ItalianLevelsDefeated = 0;

    [Header("Cartel")]
    [Range(0, 150)]
    public int CartelInfluence = 100;
    public int CartelLevelsDefeated = 0;

    [Header("Yakuza")]
    [Range(0, 150)]
    public int YakuzaInfluence = 100;
    public int YakuzaLevelsDefeated = 0;

    [Header("Russian")]
    [Range(0,150)]
    public int RussianInfluence = 100;
    public int RussianLevelsDefeated = 0;

    // arrays for influence levels

    public int[] MostEffected = new int [5];
    public int[] SecondEffected = new int[5];
    public int[] ThirdEffected = new int[5];
    public int[] LeastEffected = new int[5];


    // Start is called before the first frame update
    void Start()
    {

        MostEffected[0] = 8;
        MostEffected[1] = 7;
        MostEffected[2] = 6;
        MostEffected[3] = 8;
        MostEffected[4] = 7;


        SecondEffected[0] = 5;
        SecondEffected[1] = 4;
        SecondEffected[2] = 4;
        SecondEffected[3] = 5;
        SecondEffected[4] = 6;


        ThirdEffected[0] = 4;
        ThirdEffected[1] = 5;
        ThirdEffected[2] = 5;
        ThirdEffected[3] = 4;
        ThirdEffected[4] = 4;

        LeastEffected[0] = 3;
        LeastEffected[1] = 4;
        LeastEffected[2] = 5;
        LeastEffected[3] = 3;
        LeastEffected[4] = 3;
    }

  

    // Update is called once per frame
    void Update()
    {
        
    }
}
