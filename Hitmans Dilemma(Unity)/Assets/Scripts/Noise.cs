using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noise : MonoBehaviour
{

    // Takes in noise Level arguments from other and sends it to listening scripts on enemies.

    Traps TrapNoise;  // Call to the trap script 
     
    float NonAlert;     // used to store the data from the trap script.
    float InvestAlert;  // used to store the data from the trap script.
    float Alert;        // used to store the data from the trap script.

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

}
