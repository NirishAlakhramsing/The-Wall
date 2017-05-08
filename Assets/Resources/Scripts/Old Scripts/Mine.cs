using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mine : MonoBehaviour {

	private int miningTimes, miningCount;
	private bool canMine;
	private GameObject oreChunk;
    private GameObject childVein;

    private Mesh currentMesh;
    private GameObject childObj;

	public GameObject[] oreTypes;
    private Transform objLeo;

    public GameObject countVein;
	OreVeinManagerScript orescript;
    OreVeinObjectScript oreModelScript;

    // Use this for initialization
    void Start () {

		miningCount = 0;

		oreChunk = oreTypes[0];
		canMine = false;
		miningTimes = (int)Random.Range (5, 9);

		countVein = GameObject.Find ("OreVeinManager");
		orescript = countVein.GetComponent<OreVeinManagerScript> ();
        oreModelScript = transform.GetComponentInChildren<OreVeinObjectScript>();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetMouseButtonDown(0) && canMine == true) {
            //old code
            /*
            transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
            */

            //check which miningtime its in and set the correct model

            switch (miningCount)
            {
                case 0:
                    //gameObject.
                    //objLeo = transform.GetChild(0);
                    //objLeo = orescript.orevein[0].transform;
                    
                    //ClearChilderen();
                    //oreModelScript.createObject(1);
                    
                    currentMesh = orescript.orevein[0].GetComponent<MeshFilter>().sharedMesh;
                    gameObject.GetComponentInChildren<MeshFilter>().mesh = currentMesh;
                    //childVein.gameObject.GetComponent<MeshFilter>().mesh = currentMesh;
                    break;
                case 1:
                    //objLeo = transform.GetChild(0);
                    //objLeo = orescript.orevein[1].transform;

                    //ClearChilderen();
                   // oreModelScript.createObject(2);

                    currentMesh = orescript.orevein[1].GetComponent<MeshFilter>().sharedMesh;
                    gameObject.GetComponentInChildren<MeshFilter>().mesh = currentMesh;
                    //childVein.gameObject.GetComponent<MeshFilter>().mesh = currentMesh;
                    break;
                case 2:
                    //objLeo = transform.GetChild(0);
                    //objLeo = orescript.orevein[2].transform;

                    //ClearChilderen();
                    //oreModelScript.createObject(3);

                    currentMesh = orescript.orevein[2].GetComponent<MeshFilter>().sharedMesh;
                    gameObject.GetComponentInChildren<MeshFilter>().mesh = currentMesh;
                    //childVein.gameObject.GetComponent<MeshFilter>().mesh = currentMesh;
                    break;
                case 3:
                    //objLeo = transform.GetChild(0);
                    //objLeo = orescript.orevein[3].transform;

                    //ClearChilderen();
                    //oreModelScript.createObject(4);

                    currentMesh = orescript.orevein[3].GetComponent<MeshFilter>().sharedMesh;
                    gameObject.GetComponentInChildren<MeshFilter>().mesh = currentMesh;
                    //childVein.gameObject.GetComponent<MeshFilter>().mesh = currentMesh;
                    break;
                case 4:
                    //ClearChilderen();
                    //oreModelScript.createObject(5);

                    currentMesh = orescript.orevein[4].GetComponent<MeshFilter>().sharedMesh;
                    gameObject.GetComponentInChildren<MeshFilter>().mesh = currentMesh;
                    //childVein.gameObject.GetComponent<MeshFilter>().mesh = currentMesh;
                    break;
                case 5:
                    //ClearChilderen();
                    //oreModelScript.createObject(6);

                    currentMesh = orescript.orevein[5].GetComponent<MeshFilter>().sharedMesh;
                    gameObject.GetComponentInChildren<MeshFilter>().mesh = currentMesh;
                    //childVein.gameObject.GetComponent<MeshFilter>().mesh = currentMesh;
                    break;
                case 6:
                    //ClearChilderen();
                    //oreModelScript.createObject(7);

                    currentMesh = orescript.orevein[6].GetComponent<MeshFilter>().sharedMesh;
                    gameObject.GetComponentInChildren<MeshFilter>().mesh = currentMesh;
                    //childVein.gameObject.GetComponent<MeshFilter>().mesh = currentMesh;
                    break;
                case 7:
                    //ClearChilderen();
                    //oreModelScript.createObject(8);

                    currentMesh = orescript.orevein[7].GetComponent<MeshFilter>().sharedMesh;
                    gameObject.GetComponentInChildren<MeshFilter>().mesh = currentMesh;
                    //childVein.gameObject.GetComponent<MeshFilter>().mesh = currentMesh;
                    break;
                case 8:
                    //ClearChilderen();
                    //oreModelScript.createObject(9);

                    currentMesh = orescript.orevein[8].GetComponent<MeshFilter>().sharedMesh;
                    gameObject.GetComponentInChildren<MeshFilter>().mesh = currentMesh;
                    //childVein.gameObject.GetComponent<MeshFilter>().mesh = currentMesh;
                    break;
                case 9:
                    //ClearChilderen();
                    //oreModelScript.createObject(9);

                    currentMesh = orescript.orevein[9].GetComponent<MeshFilter>().sharedMesh;
                    gameObject.GetComponentInChildren<MeshFilter>().mesh = currentMesh;
                    //childVein.gameObject.GetComponent<MeshFilter>().mesh = currentMesh;
                    break;
                default:
                    break;
            }

            CreateOreChunks();
			miningCount++;
		}

		if (miningCount == miningTimes) {

			//orescript.maxVeins--;
			orescript.veinCount--;
			//orescript.startSpawning = true;
			Destroy(gameObject);
		}


	}
    void ClearChilderen()
    {

        if (transform.childCount >= 1)
        {
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
    }

	void OnMouseEnter() {
		canMine = true;

	}

	void OnMouseExit() {
		canMine = false;
	}

	public void CreateOreChunks(){

		Instantiate (oreChunk, transform.position, Quaternion.identity);

	}

	public void CreateBrickChunks(Vector3 getOther){
		Instantiate (oreChunk, getOther, Quaternion.identity);
	}
}
