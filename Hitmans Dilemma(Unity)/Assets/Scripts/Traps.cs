using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Traps : MonoBehaviour
{
    // this script will be used to determine trap type (light, med, heavy), atk power, stock, regenerate, and can pass on noise level to noise script.
    // need to create a level of sound function to distinguish distance of noise alert level. There are three alert types Non-Alert, Investigative Alert, Full alert.
    // Non-Alert = does not trigger and change of behavoir in enemies.
    // Investigative Alert = this triggers only the ones that hear the trap to investigate.
    // Full Alert = has all enemies respond to the location of the trap and search for the player.


    //---------need to do
    // - create noise levels
    // - noise sections to pass
    // - Identify distance for damage for levels.
    // - Make damage decrease over distance.

    [Header("Name of trap")]
    public string Name = ("name here");
    public GameObject TrapModel;
    [Header("Trap Type")]
    [Header("Determines the slot the player uses for the trap.")]
    public bool Heavy = false;
    public bool Medium = false;
    public bool Light = false;

    [Header("Trap Stats")]
    [Header("This applies to all levels of noise, so damage can be dealt three times to an enemy if they are close enough.")]
    [Range(0, 100)]
    public int atk = 0;


    [Range(0, 10)]
    [Header("How many the player can carry")]
    public int Stock = 0;
    [Range(0, 100)]
    public float Terror = 0;

    [Header("how long it takes before a trap can generate +1 in stock.")]
    [Range(0, 180)]
    public float RegenerateRate = 0;

    [Header("Auto detonate time")]
    public float AutoDetonate = 0f;

    [Range(0, 10)]
    public int AlertRadius = 0;
    [Range(0, 10)]
    public int InvestigationRadius = 0;
    [Range(0, 10)]
    public int NonAlertRadius = 0;

    [Header("is used to set off trap!! very important")]
    public bool Triggered = false;
    //---------------------------------------------------------------Non Visable Variables---------------------------------------------------------------------------------------

    Vector3 Origin;
    private int Radius = 50;
    public LayerMask Enemy;
    EnemyHealth EHealth;

    Vector3 EPos;
    string SName;

    public Collider[] Alert;
    public Collider[] NonAlerted;
    public Collider[] investigating;

    bool NonAlert = false;
    bool Investigating = false;
    bool Alerted = false;

    // Start is called before the first frame update
    void Start()
    {
        Origin = transform.position;
        SName = Name;
        this.transform.name = SName;
    }

    // Update is called once per frame
    void Update()
    {
        // autodetonate variable
        AutoDetonate -= Time.deltaTime;

        if (Triggered || AutoDetonate < 0)
        {
            CollectNonAlertedEnemies();
            CollectInvestegatingEnemies();
            CollectAlertedEnemies();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Radius * AlertRadius);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, Radius * InvestigationRadius);

        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, Radius * NonAlertRadius);
    }

    public void CollectAlertedEnemies()
    {
        Alert = Physics.OverlapSphere(Origin, Radius * AlertRadius, Enemy);
        
        // Grab Health scripts from enemies and send to Damage function
        for (int i = 0; i < Alert.Length; i++)
        {
            EHealth = Alert[i].GetComponent<EnemyHealth>();
            Alerted = true;
            Investigating = false;
            NonAlert = false;

            DamageEnemies();
        }

        Triggered = false;
       //  Destroy(this.gameObject);
    }

    public void CollectInvestegatingEnemies()
    {
        investigating = Physics.OverlapSphere(Origin, Radius * InvestigationRadius, Enemy);

        // Grab Health scripts from enemies and send to Damage function
        for (int i = 0; i < investigating.Length; i++)
        {
            EHealth = investigating[i].GetComponent<EnemyHealth>();
            Alerted = false;
            Investigating = true;
            NonAlert = false;

            DamageEnemies();
        }
       // Triggered = false;
       //  Destroy(this.gameObject);
    }

    public void CollectNonAlertedEnemies()
    {
        NonAlerted = Physics.OverlapSphere(Origin, Radius * NonAlertRadius, Enemy);

        // Grab Health scripts from enemies and send to Damage function
        for (int i = 0; i < NonAlerted.Length; i++)
        {
            EHealth = NonAlerted[i].GetComponent<EnemyHealth>();
            Alerted = false;
            Investigating = false;
            NonAlert = true;

            DamageEnemies();
        }
      
    }

    void DamageEnemies()
    {
        //Send damage to enemy Health Scripts
        if (Alerted)
        { 
             EHealth.DamageEnemy(atk, Terror);
             EHealth.Alerted = true;


         
        }
        if (Investigating && !Alerted)
        {
            EHealth.DamageEnemy(atk, Terror);
            EHealth.Investigating = true;


        
        }
        if (NonAlert && !Investigating && !Alerted)
        {
            EHealth.DamageEnemy(atk, Terror);
            EHealth.NotAlerted = true;


         
        }
        Triggered = false;
        Destroy(this.gameObject);
    }

    
}
