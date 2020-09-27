using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    float Attacked;
    public float health = 150f;
    float TerrorDMG;
    public float TerrorHealth = 150f;

    // alert bools to be swithced by traps script
    public bool NotAlerted = false;
    public bool Investigating = false;
    public bool Alerted = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void DamageEnemy(float atk, float Ter)
    {
        Attacked = atk;
        health -= Attacked;
        TerrorDMG = Ter;
        TerrorHealth -= TerrorDMG;

    }

    void AlertStatus()
    {
        if (NotAlerted && !Investigating && !Alerted)
        {
            Debug.Log("must be nothing.");
            ResetAll();

        }

        if (Investigating && !Alerted)
        {
            Debug.Log("what was that! better go look.");
            ResetAll();
        }

        if (Alerted)
        {
            Debug.Log("Hey everyone, he is over here!");
            ResetAll();
        }
    }

    void ResetAll()
    {
        NotAlerted = false;
        Investigating = false;
        Alerted = false;
}

    // Update is called once per frame
    void Update()
    {
        if (NotAlerted && !Investigating && !Alerted)
        {
            AlertStatus();
        }

        if (Investigating && !Alerted)
        {
            AlertStatus();
        }

        if (Alerted)
        {
            AlertStatus();
        }
    }
}
