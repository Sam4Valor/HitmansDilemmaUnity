using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrapManager : MonoBehaviour
{

    [Header("Player Traps")]
    // Variables for picking traps 
    public GameObject LightTrap;
    public GameObject MediumTrap;
    public GameObject HeavyTrap;

    [Header("Trap Stock")]
    public int LightStock;
    public int MediumStock;
    public int HeavyStock;

    [Header("Regenerate Rates")]
    public float LightReg;
    public float MediumReg;
    public float HeavyReg;

    //====================================================================Non-visable Variables============================================================================
    // future point for wheere to deploy trap
    //public Transform DeployPoint;

    Traps LightTrapScript;
    Traps MediumTrapScript;
    Traps HeavyTrapScript;

    public bool DeployHeavy = false;
    public bool DeployMedium = false;
    public bool DeployLight = false;

    public float LightCount;
    public float MediumCount;
    public float HeavyCount;

    int CHeavyStock;
    int CMediumStock;
    int CLightStock;


    // Start is called before the first frame update
    void Start()
    {
        // Grab script references from gameobjects
        LightTrapScript = LightTrap.GetComponent<Traps>();
        MediumTrapScript = MediumTrap.GetComponent<Traps>();
        HeavyTrapScript = HeavyTrap.GetComponent<Traps>();

        // Assign Stock Variables
        CLightStock = LightTrapScript.Stock;
        LightStock = CLightStock;

        CMediumStock = MediumTrapScript.Stock;
        MediumStock = CMediumStock;

        CHeavyStock = HeavyTrapScript.Stock;
        HeavyStock = CHeavyStock;


        // Assign Regeneration Rates
        LightReg = LightTrapScript.RegenerateRate;
        MediumReg = MediumTrapScript.RegenerateRate;
        HeavyReg = HeavyTrapScript.RegenerateRate;

        LightCount = LightReg;
        MediumCount = MediumReg;
        HeavyCount = HeavyReg;

    }

    // Update is called once per frame
    void Update()
    {
        // Deploy Heavy Trap
        if (Input.GetKeyDown(KeyCode.H) && HeavyStock > 0)
        {
            Debug.Log("Deployed Heavy Trap");
            DeployHeavy = true;
            DeployTrap();
        }
        // Deploy Medium Trap
        if (Input.GetKeyDown(KeyCode.M) && MediumStock > 0)
        {
            Debug.Log("Deployed Medium Trap");
            DeployMedium = true;
            DeployTrap();
        }
        // Deploy Small Trap
        if (Input.GetKeyDown(KeyCode.S) && LightStock > 0)
        {
            Debug.Log("Deployed Light Trap");
            DeployLight = true;
            DeployTrap();
        }

        // used to regen stock for traps
        if (HeavyStock < CHeavyStock)
        {
            HeavyCount -= Time.deltaTime;
            if (HeavyCount< 0)
            {
                Debug.Log("ReStocking Heavy");
                HeavyStock += 1;
                HeavyCount = HeavyReg;
            }
        }

        if (MediumStock < CMediumStock)
        {
            MediumCount -= Time.deltaTime;
            if (MediumCount < 0)
            {
                Debug.Log("ReStocking Medium");
                MediumStock += 1;
                MediumCount = MediumReg;
            }
        }

        if (LightStock < CLightStock)
        {
            LightCount -= Time.deltaTime;
            if (LightCount < 0)
            {
                Debug.Log("ReStocking Light");
                LightStock += 1;
                LightCount = LightReg;
            }
        }

    }

    void DeployTrap()
    {
        if (DeployHeavy)
        {
            // Instantiate(HeavyTrap, DeployPoint);
            Instantiate(HeavyTrap, this.transform);
            HeavyStock -= 1;
            DeployHeavy = false;
        }

        if (DeployMedium)
        {
            // Instantiate(MediumTrap, DeployPoint);
            Instantiate(MediumTrap,this.transform);
            MediumStock -= 1;
            DeployMedium = false;
        }

        if (DeployLight)
        {
            // Instantiate(HeavyTrap, DeployPoint);
            Instantiate(LightTrap, this.transform);
            LightStock -= 1;
            DeployLight = false;
            Debug.Log("Light Trap has been deployed!!");
        }
    
    }
}
