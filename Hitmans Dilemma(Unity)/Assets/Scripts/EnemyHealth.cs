using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    float Attacked;
    public float health = 150f;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void DamageEnemy(float atk)
    {
        Attacked= atk;
        health -= Attacked;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
