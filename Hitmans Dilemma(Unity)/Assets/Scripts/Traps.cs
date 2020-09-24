using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Traps : MonoBehaviour
{
    // this script will be used to determine trap type (light, med, heavy), atk power, stock, regenerate, and can pass on noise level to noise script.
    //
    [Header("Name of trap")]
    public string Name = ("name here");
    public GameObject TrapModel;
    [Header("Trap Type")]
    [Header("Determines the slot the player uses for the trap.")]
    public bool Heavy = false;
    public bool Medium = false;
    public bool Light = false;

    [Header("Trap Stats")]
    [Range(0, 100)]
    public int atk = 0;
    [Range(0, 10)]
    [Header("How many the player can carry")]
    public int Stock = 0;

    [Header("how long it takes before a trap can generate +1 in stock.")]
    [Range(0, 180)]
    public float RegenerateRate = 0;

    [Header("Auto detonate time")]
    public float AutoDetonate = 0f;

    [Range(0, 10)]
    public int NoiseLevel = 0;

    [Header("is used to set off trap!! very important")]
    public bool Triggered = false;
    //---------------------------------------------------------------Non Visable Variables---------------------------------------------------------------------------------------

    Vector3 Origin;
    private int Radius = 50;
    public LayerMask Enemy;
    EnemyHealth EHealth;

    public Collider[] Enemies;
    // private int direction;



    // Start is called before the first frame update
    void Start()
    {
        Origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // autodetonate variable
        AutoDetonate -= Time.deltaTime;
        if (AutoDetonate < 0)
        {
            
        }
        if (Triggered || AutoDetonate < 0)
        {
            CollectEnemies();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Radius * NoiseLevel);

    }

    public void CollectEnemies ()
    {
        Enemies = Physics.OverlapSphere(Origin, Radius * NoiseLevel, Enemy);
        // Grab Health scripts from enemies and send to Damage function
        for (int i = 0; i < Enemies.Length; i++)
        {
            EHealth = Enemies[i].GetComponent<EnemyHealth>();
            DamageEnemies();
        }
        Triggered = false;
        Destroy(this.gameObject);
    }

    void DamageEnemies()
    {
        //Send damage to enemy Health Scripts
        EHealth.DamageEnemy(atk);
    }
}
