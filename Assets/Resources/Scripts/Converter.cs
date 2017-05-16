﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]

public class Converter : MonoBehaviour {

    //Grid data from the generatorscript
    private GameObject[] generatorDataObj;
    private int arraySize = 16; //This data needs to be fetched from the future script which generates the data.

    //Grid data in scene
    public int xSize, ySize;
    private Vector3[] cell;
    public float waitTime;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //Gather size of array
    void fetchData()
    {

        for (int i = 0; i < arraySize; i++)
        {


        }

    }

    public void InvokeMethods(int nr)
    {
        if (nr == 1)
        {
            StartCoroutine(Generate());
        }
    }

    private IEnumerator Generate()
    {
        WaitForSeconds wait = new WaitForSeconds(waitTime);

        Debug.Log("Creating grid size");
        
        cell = new Vector3[(xSize +1 ) * (ySize + 1)];
        for (int i = 0, y = 0; y <= ySize; y++)
        {
            for (int x = 0; x <= xSize; x++, i++)
            {
                cell[i] = new Vector3(gameObject.transform.position.x +(x * 1.5f), 0, gameObject.transform.position.z + (y * 1.5f));
                yield return wait;
            }
        }
        
    }

    //Just to display the positions of the grid field with sphere primitives -- replace this with the data from the generator
    private void OnDrawGizmosSelected()
    {
        if (cell == null)
        {
            return;
        }

        Gizmos.color = Color.black;
        for (int i = 0; i < cell.Length; i++)
        {
            Gizmos.DrawSphere(cell[i], 0.1f);
            
        }
    }

}
