using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerGen : MonoBehaviour
{

    public GameObject[] spawnPoints; // holds all spawn points
    GameObject[] ChangeLocations = new GameObject[6];
    public GameObject Spawner;  // empty game object that will spawn enemies.

    public int[] pointsVer = new int[12]; // holds all Z locations
    public int[] pointsHor = new int[12]; // holds all X locations
    

    int VerPoint; // Z location
    int HorPoint; // X location
    int SpawnCount = 0; // counts number of current spawn points

    PlatformRandomizer PlatformScript;

    public bool Extra = false;

    // Start is called before the first frame update
    void Start()
    {
        PlatformScript = GetComponent<PlatformRandomizer>();
        Extra = PlatformScript.SecondPlatform;

        pointsVer[0] = 300;
        pointsVer[1] = 500;
        pointsVer[2] = 700;
        pointsVer[3] = 900;
        pointsVer[4] = 1100;
        pointsVer[5] = 1300;
        pointsVer[6] = 1500;
        pointsVer[7] = 1700;
        //Extra Plateform points
        pointsVer[8] = 1100;
        pointsVer[9] = 1300;
        pointsVer[10] = 1500;
        pointsVer[11] = 1700;
        pointsVer[12] = 1900;

        pointsHor[0] = -300;
        pointsHor[1] = -500;
        pointsHor[2] = -700;
        pointsHor[3] = -900;
        pointsHor[4] = -1100;
        pointsHor[5] = -1300;
        pointsHor[6] = -1500;
        pointsHor[7] = -1700;
        //Extra Plateform points
        pointsHor[8] = -100;
        pointsHor[9] = 100;
        pointsHor[10] = 500;
        pointsHor[11] = 700;
        pointsHor[12] = 900;


        RandomPoint(VerPoint, HorPoint);
    }

    void RandomPoint(int Ver, int Hor)
    {
        if (SpawnCount < 12)
        {
            // Randomize locations for Spawn Points.
            Ver = Random.Range(0, 7);
            Hor = Random.Range(0, 7);

            VerPoint = Ver;
            HorPoint = Hor;
            SpawnPoints();
        }

        if (Extra && SpawnCount <= 14)
        {
            // Randomize locations for Spawn Points with extra platform points.
            Ver = Random.Range(8, 12);
            Hor = Random.Range(8, 12);

            VerPoint = Ver;
            HorPoint = Hor;
            SpawnPoints();
        }

    }

    void SpawnPoints()
    {
        if (SpawnCount < 12)
        {
            // Spawn a new spawner, move its location from randomizer, and finally assign spawn point to array to be called.
            Instantiate(Spawner, this.transform);
            Spawner.transform.position = new Vector3(pointsHor[HorPoint], 10, pointsVer[VerPoint]);
            spawnPoints[SpawnCount] = Spawner;
            CheckPosition(Spawner);
           // SpawnCount += 1;

          //  RandomPoint(VerPoint, HorPoint);
        }
        if (SpawnCount <= 14 && Extra)
        {
            Instantiate(Spawner, this.transform);
            Spawner.transform.position = new Vector3(pointsHor[HorPoint], 10, pointsVer[VerPoint]);
            spawnPoints[SpawnCount] = Spawner;
            CheckPosition(Spawner);

            //SpawnCount += 1;

           // RandomPoint(VerPoint, HorPoint);
        }

    }

    void CheckPosition (GameObject NewSpawner)
    {
        // used to check spawner position do not overlap.
        for(int Point = 0; Point < spawnPoints.Length; Point++) 
        {
            if (spawnPoints[Point].transform.position == NewSpawner.transform.position)
            {
                // ChangePosition(VerPoint, HorPoint);
                ChangeLocations[Point] = NewSpawner;
            }
            if (spawnPoints[Point].transform.position != NewSpawner.transform.position)
            {
                spawnPoints[SpawnCount] = Spawner;
                SpawnCount += 1;
            }
        }
        RandomPoint(VerPoint, HorPoint);
    }
    void ChangePosition(int Ver, int Hor)
    {
        if (0 < ChangeLocations.Length)
        {

        }

        if (SpawnCount < 12)
        {
            // Randomize locations for Spawn Points.
            Ver = Random.Range(0, 7);
            Hor = Random.Range(0, 7);

            VerPoint = Ver;
            HorPoint = Hor;
            CheckPosition(Spawner);
        }

        if (Extra && SpawnCount <= 14)
        {
            // Randomize locations for Spawn Points with extra platform points.
            Ver = Random.Range(8, 12);
            Hor = Random.Range(8, 12);

            VerPoint = Ver;
            HorPoint = Hor;
            CheckPosition(Spawner);
        }

    }
}
