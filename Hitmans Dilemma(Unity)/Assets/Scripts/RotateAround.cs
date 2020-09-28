using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{


    public GameObject target; //What to spin aroound.
    public float Speed = 80;
    public bool Alive = true;
    
    
    //  






    void Start()
    {
      
    }

    void Reset()
    {
        Alive = true;

    }

    // Update is called once per frame

    void Update()
    {
        if (!Alive)
        {
            // Spin the object around the target at 20 degrees/second.
            transform.RotateAround(target.transform.position, Vector3.up, Speed * Time.deltaTime);
        }
        
    }
    
    
}
