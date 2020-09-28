using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    float Attacked;
    public float health = 150f;
    float Rhealth;
    float TerrorDMG;
    public float TerrorHealth = 150f;

    // alert bools to be swithced by traps script
    public bool NotAlerted = false;
    public bool Investigating = false;
    public bool Alerted = false;

    // Knock Out animations.
    [Header("Knock Out animations Gameobject!")]

    [Range(0,1000)]
    public float revive;
    float RRevive;

    public GameObject StarOne;
    public GameObject StarTwo;
    public GameObject StarThree;

    // Timers for Stars!
    [Header("Star timers for knockout")]
    public float StarOneT;

    public float StarTwoT;

    public float StarThreeT;

    bool OneReset = false;
    bool TwoReset = false;
    bool Out = false;

    // script calls for scripts.
    RotateAround StarOneScript;
    RotateAround StarTwoScript;
    RotateAround StarThreeScript;


    // Start is called before the first frame update
    void Start()
    {
        StarOne.SetActive(false);
        StarTwo.SetActive(false);
        StarThree.SetActive(false);


        Rhealth = health;
        RRevive = revive;


        StarOneScript = StarOne.gameObject.GetComponent<RotateAround>();
        StarTwoScript = StarTwo.gameObject.GetComponent<RotateAround>();
        StarThreeScript = StarThree.gameObject.GetComponent<RotateAround>();
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
        if (health <= 0)
        {
            revive -= Time.deltaTime;
            KnockOut();
        }
    }

    void ResetAll()
    {
        NotAlerted = false;
        Investigating = false;
        Alerted = false;

    }

    void KnockOut()
    {
        // set stars to active
        StarOne.gameObject.SetActive (true);
        StarOneScript.Alive = false;
        
        StarTwo.gameObject.SetActive(true);
        StarTwoScript.Alive = false;

        StarThree.gameObject.SetActive(true);
        StarThreeScript.Alive = false;
    }

    void Revive()
    {
        revive = RRevive;
        health = Rhealth / 2;
        OneReset = false;
        TwoReset = false;
        Out = false;
    }

    

    // Update is called once per frame
    void Update()
    {
        if (health <= 0 && !Out)
        {
            Debug.Log("Enemy health is at zero");
            KnockOut();
            Out = true;
        }
        if (health <= 0)
        {
            revive -= Time.deltaTime;
        }
        if (revive < StarOneT && !OneReset)
        {
            StarOne.gameObject.SetActive(false);
            OneReset = true;
        }
        if (revive < StarTwoT && !TwoReset)
        {
            StarTwo.gameObject.SetActive(false);
            TwoReset = true;
        }
        if (revive <= 0)
        {
            StarThree.gameObject.SetActive(false);
            Revive();
        }


        // likely going to swith this code under into a state machine.
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
