using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    float Attacked;
    public float health = 150f;
    float TerrorDMG;
    float TerrorHealth = 150f;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void DamageEnemy(float atk, float Ter)
    {
        Attacked= atk;
        health -= Attacked;
        TerrorDMG = Ter;
        TerrorHealth -= TerrorDMG;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
