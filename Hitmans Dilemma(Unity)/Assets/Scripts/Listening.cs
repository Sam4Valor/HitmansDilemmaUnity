using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listening : MonoBehaviour
{

    //Listens to other scripts to determine response to noise.

        [Header("Alerts")]

        public bool NonAlert;
        public bool InvestigativeAlert;
        public bool Alert;

    [Header("Alert resets")]

    public float InvestRes;
    public float AlertRes;

    Noise noise;
    Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        position = this.transform.position;
    }

    void NoiseLevel()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
