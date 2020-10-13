using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{

    public InfluenceCal Influence;
    
    public string[] Mob = new string [5];

    int deduction;

    public string MobName;
    public int SelectMob;

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
        Mob[4] = "Italian";

        MobName = Mob[SelectMob];
        
    }

    void MostEffected()
    {
        if (Mob[SelectMob] == "Yakuza")
        {
            // 
            mobSel = Influence.YakuzaLevelsDefeated;
   

            Influence.YakuzaInfluence -= 20;

          
            Influence.YakuzaLevelsDefeated += 1;

            Influence.CartelInfluence += Influence.MostEffected[mobSel];
            Influence.IRAInfluence += Influence.SecondEffected[mobSel];
            Influence.RussianInfluence += Influence.ThirdEffected[mobSel];
            Influence.ItalianInfluence += Influence.LeastEffected[mobSel];

            Done = false;
        }

        if (Mob[SelectMob] == "IRA")
        {
            mobSel = Influence.IRALevelsDefeated;
            
            Influence.IRAInfluence -= 20;

            Influence.IRALevelsDefeated += 1;

            Influence.RussianInfluence+= Influence.MostEffected[mobSel];
            Influence.ItalianInfluence += Influence.SecondEffected[mobSel];
            Influence.YakuzaInfluence += Influence.ThirdEffected[mobSel];
            Influence.CartelInfluence += Influence.LeastEffected[mobSel];

            Done = false;

        }

        if (Mob[SelectMob] == "Italian")
        {
            mobSel = Influence.ItalianLevelsDefeated;
         
            Influence.ItalianInfluence -= 20;

            Influence.YakuzaInfluence += Influence.MostEffected[mobSel];
            Influence.CartelInfluence += Influence.SecondEffected[mobSel];
            Influence.IRAInfluence += Influence.ThirdEffected[mobSel];
            Influence.RussianInfluence += Influence.LeastEffected[mobSel];

            Done = false;
        }
        if (Mob[SelectMob] == "Russian")
        {
            mobSel = Influence.RussianLevelsDefeated;
        
            
            Influence.RussianInfluence -= 20;
            Influence.ItalianInfluence += Influence.MostEffected[mobSel];
            Influence.YakuzaInfluence += Influence.SecondEffected[mobSel];
            Influence.CartelInfluence += Influence.ThirdEffected[mobSel];
            Influence.IRAInfluence += Influence.LeastEffected[mobSel];


            Influence.RussianLevelsDefeated += 1;
            Done = false;
        }

        if (Mob[SelectMob] == "Cartel")
        {
            mobSel = Influence.CartelLevelsDefeated;
            Influence.CartelInfluence -= 20;


            Influence.RussianLevelsDefeated += 1;
            Influence.IRAInfluence += Influence.MostEffected[mobSel];
            Influence.RussianInfluence += Influence.SecondEffected[mobSel];
            Influence.ItalianInfluence += Influence.ThirdEffected[mobSel];
            Influence.YakuzaInfluence += Influence.LeastEffected[mobSel];

            Done = false;
        }
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
