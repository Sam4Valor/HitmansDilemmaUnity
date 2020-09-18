using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterRandomizer : MonoBehaviour
{

    // variables for teleporter row and column select.
    public GameObject Teleporter;
    public int[] ColumnSel = new int[9];
    public int[] RowSel = new int[9];
    int Column;
    int Row;

    GameObject LastTeleporter;
    GameObject NewTeleporter;
    int Created = 0;
    // color variable
    int Set = 0;
    Renderer ColorOne;
    Renderer ColorTwo;
    // Start is called before the first frame update
    void Start()
    {
        // Filling the array with Column and Row data.
        ColumnSel[0] = -100;
        ColumnSel[1] = -300;
        ColumnSel[2] = -500;
        ColumnSel[3] = -700;
        ColumnSel[4] = -900;
        ColumnSel[5] = -1100;
        ColumnSel[6] = -1300;
        ColumnSel[7] = -1500;
        ColumnSel[8] = -1700;

        RowSel[0] = 100;
        RowSel[1] = 300;
        RowSel[2] = 500;
        RowSel[3] = 700;
        RowSel[4] = 900;
        RowSel[5] = 1100;
        RowSel[6] = 1300;
        RowSel[7] = 1500;
        RowSel[8] = 1700;

        Randomizer(Row, Column);
    }

    void Randomizer(int row, int column)
    {
        /// Randomly select positions for teleporters
        row = Random.Range(0,8);
        Row = row;
        column = Random.Range(0,8);
        Column = column;

        Placer();
    }

    void Placer()
    {
        if (Created < 1)
        {
            NewTeleporter = Instantiate(Teleporter);
            NewTeleporter.transform.position = new Vector3(ColumnSel[Column], 10, RowSel[Row]);

           LastTeleporter = NewTeleporter;

            Created += 1;
            Randomizer(Row, Column);
        }


        // Need to create if statment that figures if their are 2 teleporters and link them to each other and color them the same.
        if (Created == 1)
        {
           NewTeleporter = Instantiate(Teleporter);
           NewTeleporter.transform.position = new Vector3(ColumnSel[Column], 10, RowSel[Row]);

           Created += 1;
           
           Linked(NewTeleporter, LastTeleporter);
        }
    }

    void Linked(GameObject New, GameObject Last)
    {

        if (Set == 0)
        {
            // will link teleporters together and color them. then reset counter.
            New.GetComponent<TeleportLink>().ExitTeleporter = Last;
            Last.GetComponent<TeleportLink>().ExitTeleporter = New;
            
            // Need to swap colors here.
            ColorOne = New.GetComponent<Renderer>();
            ColorOne.material.SetColor("_Color",Color.red);

            ColorTwo = Last.GetComponent<Renderer>();
            ColorTwo.material.SetColor("_Color", Color.red);

            Created = 0;
            Set = 1;

            Randomizer(Row, Column);
 
        }

        if (Set == 1)
        {
            // will link teleporters together and color them. then reset counter.
            New.GetComponent<TeleportLink>().ExitTeleporter = Last;
            Last.GetComponent<TeleportLink>().ExitTeleporter = New;

            // Need to swap colors here.
            ColorOne = New.GetComponent<Renderer>();
            ColorOne.material.SetColor("_Color", Color.yellow);

            ColorTwo = Last.GetComponent<Renderer>();
            ColorTwo.material.SetColor("_Color", Color.yellow);

            Created = 0;
            Set = 2;

            Randomizer(Row, Column);

        }

        if (Set == 2)
        {
            // will link teleporters together and color them. then reset counter.
            New.GetComponent<TeleportLink>().ExitTeleporter = Last;
            Last.GetComponent<TeleportLink>().ExitTeleporter = New;

            // Need to swap colors here.
            ColorOne = New.GetComponent<Renderer>();
            ColorOne.material.SetColor("_Color", Color.blue);

            ColorTwo = Last.GetComponent<Renderer>();
            ColorTwo.material.SetColor("_Color", Color.blue);

            Created = 0;
            Set = 3;

            Randomizer(Row, Column);

        }

        if (Set == 3)
        {
            // will link teleporters together and color them. then reset counter.
            New.GetComponent<TeleportLink>().ExitTeleporter = Last;
            Last.GetComponent<TeleportLink>().ExitTeleporter = New;

            // Need to swap colors here.
            ColorOne = New.GetComponent<Renderer>();
            ColorOne.material.SetColor("_Color", Color.green);

            ColorTwo = Last.GetComponent<Renderer>();
            ColorTwo.material.SetColor("_Color", Color.green);

            //Created = 0;
            Set = 4;

           // Randomizer(Row, Column);

        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
