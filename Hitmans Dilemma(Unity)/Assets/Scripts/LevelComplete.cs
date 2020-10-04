using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{

    public InfluenceCal Influence;
    
    public string[] Mob = new string [5];

    int deduction;

    int SelectMob;

    int mobSel;
    int MobIn;
    // Call LevelsDefeated from InfluenceCal script. example ("ItalianLevelsDefeated", "IRALevelsDefeated", "YakuzaLevelsDefeated", "CartelLevelsDefeated", "RussianLevelsDefeated")
    int Level;

    public bool Done = false;



    // Start is called before the first frame update
    void Start()
    {
        Mob[0] = "IRA";
        Mob[1] = "Yakuza";
        Mob[2] = "Cartel";
        Mob[3] = "Russian";
        Mob[0] = "Italian";

        
    }

    void MostEffected()
    {
        if (Mob[SelectMob] == "Yakuza")
        {
            // 
            mobSel = Influence.YakuzaLevelsDefeated;
            deduction = Influence.MostEffected[mobSel];

            Influence.YakuzaInfluence -= 20;

            MobIn = Influence.IRAInfluence;

            Influence.CalculateInfluence(MobIn, deduction);
            Influence.YakuzaLevelsDefeated += 1;
           
            SecondEffected(Influence.CartelInfluence);
            ThirdEffected(Influence.ItalianInfluence);
            LeastEffected(Influence.RussianInfluence);

            Done = false;
        }

        if (Mob[SelectMob] == "IRA")
        {
            mobSel = Influence.IRALevelsDefeated;
            deduction = Influence.MostEffected[mobSel];

            Influence.IRAInfluence -= 20;

            MobIn = Influence.CartelInfluence;

            Influence.CalculateInfluence(MobIn, deduction);
            Influence.IRALevelsDefeated += 1;

            SecondEffected(Influence.ItalianInfluence);
            ThirdEffected(Influence.RussianInfluence);
            LeastEffected(Influence.YakuzaInfluence);
        }

        if (Mob[SelectMob] == "Italian")
        {
            mobSel = Influence.ItalianLevelsDefeated;
            deduction = Influence.MostEffected[mobSel];

            Influence.ItalianInfluence -= 20;

            MobIn = Influence.RussianInfluence;


            Influence.CalculateInfluence(MobIn, deduction);
            Influence.ItalianLevelsDefeated += 1;

            SecondEffected(Influence.YakuzaInfluence);
            ThirdEffected(Influence.IRAInfluence);
            LeastEffected(Influence.CartelInfluence);

        }
        if (Mob[SelectMob] == "Russian")
        {
            mobSel = Influence.RussianLevelsDefeated;
            deduction = Influence.MostEffected[mobSel];

            Influence.RussianInfluence -= 20;

            MobIn = Influence.YakuzaInfluence;


            Influence.CalculateInfluence(MobIn, deduction);
            Influence.RussianLevelsDefeated += 1;

            SecondEffected(Influence.IRAInfluence);
            ThirdEffected(Influence.CartelInfluence);
            LeastEffected(Influence.ItalianInfluence);
        }

        if (Mob[SelectMob] == "Cartel")
        {
            mobSel = Influence.CartelLevelsDefeated;
            deduction = Influence.MostEffected[mobSel];

            Influence.CartelInfluence -= 20;

            MobIn = Influence.ItalianInfluence;


            Influence.CalculateInfluence(MobIn, deduction);
            Influence.RussianLevelsDefeated += 1;

            SecondEffected(Influence.RussianInfluence);
            ThirdEffected(Influence.YakuzaInfluence);
            LeastEffected(Influence.IRAInfluence);
        }
    }

    void SecondEffected(int SecondInfluence)
    {
        deduction = Influence.SecondEffected[mobSel];
        MobIn = SecondInfluence;
        Influence.CalculateInfluence(MobIn, deduction);
    }

    void ThirdEffected(int ThirdInfluence)
    { 
        deduction = Influence.ThirdEffected[mobSel];
        MobIn = ThirdInfluence;
        Influence.CalculateInfluence(MobIn, deduction);
    }

    void LeastEffected(int LeastInfluence)
    {
        deduction = Influence.LeastEffected[mobSel];
        MobIn = LeastInfluence;
        Influence.CalculateInfluence(MobIn, deduction);
    }
    
    
    // Update is called once per frame
    void Update()
    {
        if (Done)
        {
            MostEffected();
        }
    }
}
