using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    int size = 10;


    // Use this for initialization
    void Start()
    {
        GameObject[] Cubes = new GameObject[size];



        for (int i = 0; i < size; i++)
        {
            Cubes[i] = GameObject.Instantiate(Resources.Load("Cube") as GameObject);
            Cubes[i].transform.position = new Vector3(i * 1.2f, 0 , 0);

            for (int j = 0; j < size; j++)
            {
                Cubes[i] = GameObject.Instantiate(Resources.Load("Cube") as GameObject);
                Cubes[i].transform.position = new Vector3(i * 1.2f, j * 1.2f, 0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {


    }
}
