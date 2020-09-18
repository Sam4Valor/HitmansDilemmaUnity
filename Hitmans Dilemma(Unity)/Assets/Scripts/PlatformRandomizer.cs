using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRandomizer : MonoBehaviour
{
    public GameObject[] Platforms = new GameObject[9];
    public GameObject lastPlatform;
    GameObject NewPlatform;


    int picker;
    int rotater = 1;
    public int Created = 1;
    public int SecondCreated = 1;


    bool IsComplete = false;
    public bool SecondPlatform = false;

    // Start is called before the first frame update
    void Start()
    {
        Randomizer(picker,rotater);
    }

    void Randomizer(int Picker, int Rotater)
    {
        if (IsComplete == false)
        {
            // pickes a number and sends it back as the picker for the array.
            Picker = Random.Range(0, 9);
            picker = Picker;
            // Picks a rotation for the next platform.
            Rotater = Random.Range(0, 3);
            rotater = Rotater;

            Placer();
        }
        if (IsComplete == true)
        {
            // pickes a number and sends it back as the picker for the array.
            Picker = Random.Range(0, 9);
            picker = Picker;
            // Picks a rotation for the next platform.
            Rotater = Random.Range(0, 3);
            rotater = Rotater;

            SecondPlacer();
        }
        
    }

    void Placer()
    {
        // creates and places platforms next to each other until 10 have been created.
        if (Created < 10)
        {
            NewPlatform = Instantiate(Platforms[picker]);
            NewPlatform.transform.position = new Vector3(lastPlatform.transform.position.x - 200f, lastPlatform.transform.position.y, lastPlatform.transform.position.z);
            //     Rotation
            NewPlatform.transform.Rotate (0,90 * rotater,0) ;
            lastPlatform = NewPlatform;
            Created += 1;

            Randomizer(picker, rotater);
        }
        if (Created >= 10 && Created < 20)
        {
            NewPlatform = Instantiate(Platforms[picker]);
            NewPlatform.transform.position = new Vector3(lastPlatform.transform.position.x + 200f, lastPlatform.transform.position.y, 300);
            //     Rotation
            NewPlatform.transform.Rotate(0, 90 * rotater, 0);
            lastPlatform = NewPlatform;
            Created += 1;

            Randomizer(picker, rotater);
        }
        if (Created >= 20 && Created < 30)
        {
            NewPlatform = Instantiate(Platforms[picker]);
            NewPlatform.transform.position = new Vector3(lastPlatform.transform.position.x - 200f, lastPlatform.transform.position.y, 500);
            //     Rotation
            NewPlatform.transform.Rotate(0, 90 * rotater, 0);
            lastPlatform = NewPlatform;
            Created += 1;

            Randomizer(picker, rotater);
        }
        if (Created >= 30 && Created < 40)
        {
            NewPlatform = Instantiate(Platforms[picker]);
            NewPlatform.transform.position = new Vector3(lastPlatform.transform.position.x + 200f, lastPlatform.transform.position.y, 700);
            //     Rotation
            NewPlatform.transform.Rotate(0, 90 * rotater, 0);
            lastPlatform = NewPlatform;
            Created += 1;

            Randomizer(picker, rotater);
        }
        if (Created >= 40 && Created < 50)
        {
            NewPlatform = Instantiate(Platforms[picker]);
            NewPlatform.transform.position = new Vector3(lastPlatform.transform.position.x - 200f, lastPlatform.transform.position.y, 900);
            //     Rotation
            NewPlatform.transform.Rotate(0, 90 * rotater, 0);
            lastPlatform = NewPlatform;
            Created += 1;

            Randomizer(picker, rotater);
        }
        if (Created >= 50 && Created < 60)
        {
            NewPlatform = Instantiate(Platforms[picker]);
            NewPlatform.transform.position = new Vector3(lastPlatform.transform.position.x + 200f, lastPlatform.transform.position.y, 1100);
            //     Rotation
            NewPlatform.transform.Rotate(0, 90 * rotater, 0);
            lastPlatform = NewPlatform;
            Created += 1;

            Randomizer(picker, rotater);
        }
        if (Created >= 60 && Created < 70)
        {
            NewPlatform = Instantiate(Platforms[picker]);
            NewPlatform.transform.position = new Vector3(lastPlatform.transform.position.x - 200f, lastPlatform.transform.position.y, 1300);
            //     Rotation
            NewPlatform.transform.Rotate(0, 90 * rotater, 0);
            lastPlatform = NewPlatform;
            Created += 1;

            Randomizer(picker, rotater);
        }
        if (Created >= 70 && Created < 80)
        {
            NewPlatform = Instantiate(Platforms[picker]);
            NewPlatform.transform.position = new Vector3(lastPlatform.transform.position.x + 200f, lastPlatform.transform.position.y, 1500);
            //     Rotation
            NewPlatform.transform.Rotate(0, 90 * rotater, 0);
            lastPlatform = NewPlatform;
            Created += 1;

            Randomizer(picker, rotater);
        }
        if (Created >= 80 && Created < 90)
        {
            NewPlatform = Instantiate(Platforms[picker]);
            NewPlatform.transform.position = new Vector3(lastPlatform.transform.position.x - 200f, lastPlatform.transform.position.y, 1700);
            //     Rotation
            NewPlatform.transform.Rotate(0, 90 * rotater, 0);
            lastPlatform = NewPlatform;
            Created += 1;

            Randomizer(picker, rotater);
        }
        if (Created >= 90 && Created < 100)
        {
            NewPlatform = Instantiate(Platforms[picker]);
            NewPlatform.transform.position = new Vector3(lastPlatform.transform.position.x + 200f, lastPlatform.transform.position.y, 1900);
            //     Rotation
            NewPlatform.transform.Rotate(0, 90 * rotater, 0);
            lastPlatform = NewPlatform;
            Created += 1;

            Randomizer(picker, rotater);
        }

        IsComplete = true;
        SecondPlacer();
     
    }
        // Extra platforms from influence calculator.
        void SecondPlacer()
    {
        if (IsComplete == true && SecondPlatform == true)
        {
            if (SecondCreated <= 5)
            {
                NewPlatform = Instantiate(Platforms[picker]);
                NewPlatform.transform.position = new Vector3(lastPlatform.transform.position.x + 200f, lastPlatform.transform.position.y, 1900);
                //     Rotation
                NewPlatform.transform.Rotate(0, 90 * rotater, 0);
                lastPlatform = NewPlatform;

                SecondCreated += 1;

                Randomizer(picker, rotater);
            }
            if (SecondCreated > 5 && SecondCreated <= 11)
            {
                NewPlatform = Instantiate(Platforms[picker]);
                NewPlatform.transform.position = new Vector3(lastPlatform.transform.position.x - 200f, lastPlatform.transform.position.y, 1700);
                //     Rotation
                NewPlatform.transform.Rotate(0, 90 * rotater, 0);
                lastPlatform = NewPlatform;

                SecondCreated += 1;

                Randomizer(picker, rotater);
            }
            if (SecondCreated > 11 && SecondCreated <= 17)
            {
                NewPlatform = Instantiate(Platforms[picker]);
                NewPlatform.transform.position = new Vector3(lastPlatform.transform.position.x + 200f, lastPlatform.transform.position.y, 1500);
                //     Rotation
                NewPlatform.transform.Rotate(0, 90 * rotater, 0);
                lastPlatform = NewPlatform;

                SecondCreated += 1;

                Randomizer(picker, rotater);
            }
            if (SecondCreated > 17 && SecondCreated <= 23)
            {
                NewPlatform = Instantiate(Platforms[picker]);
                NewPlatform.transform.position = new Vector3(lastPlatform.transform.position.x - 200f, lastPlatform.transform.position.y, 1300);
                //     Rotation
                NewPlatform.transform.Rotate(0, 90 * rotater, 0);
                lastPlatform = NewPlatform;

                SecondCreated += 1;

                Randomizer(picker, rotater);
            }
            if (SecondCreated > 23 && SecondCreated <= 29)
            {
                NewPlatform = Instantiate(Platforms[picker]);
                NewPlatform.transform.position = new Vector3(lastPlatform.transform.position.x + 200f, lastPlatform.transform.position.y, 1100);
                //     Rotation
                NewPlatform.transform.Rotate(0, 90 * rotater, 0);
                lastPlatform = NewPlatform;

                SecondCreated += 1;

                Randomizer(picker, rotater);
            }
        }
    }
}
