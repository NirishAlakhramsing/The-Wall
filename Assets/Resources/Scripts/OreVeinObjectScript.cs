using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OreVeinObjectScript : MonoBehaviour {

    public GameObject[] oremeshes;
    OreVeinManagerScript orescript;
    public GameObject countVein;
    private Transform parentObj;

    // Use this for initialization
    void Start () {
        parentObj = transform.parent;
        Debug.Log(transform.parent);

        countVein = GameObject.Find("OreVeinManager");
        orescript = countVein.GetComponent<OreVeinManagerScript>();

        /*for (int i = 0; i < orescript.oremeshes.Length; i++)
        {
            oremeshes[i] = orescript.orevein[i];
        }*/
        //createObject(0);

    }

    // Update is called once per frame
    void Update () {
	
	}

    public void createObject(int modelNr)
    {
        switch (modelNr)
        {
            case 0:
                Instantiate(orescript.orevein[0], transform.position, Quaternion.identity);
                gameObject.transform.parent = parentObj.transform;

                break;

            case 1:
                Instantiate(orescript.orevein[1], transform.position, Quaternion.identity);
                gameObject.transform.parent = parentObj.transform;
                break;

            case 2:
                Instantiate(orescript.orevein[2], transform.position, Quaternion.identity);
                gameObject.transform.parent = parentObj.transform;
                break;

            case 3:
                Instantiate(orescript.orevein[3], transform.position, Quaternion.identity);
                gameObject.transform.parent = parentObj.transform;
                break;

            case 4:
                Instantiate(orescript.orevein[4], transform.position, Quaternion.identity);
                gameObject.transform.parent = parentObj.transform;
                break;

            case 5:
                Instantiate(orescript.orevein[5], transform.position, Quaternion.identity);
                gameObject.transform.parent = parentObj.transform;
                break;

            case 6:
                Instantiate(orescript.orevein[6], transform.position, Quaternion.identity);
                gameObject.transform.parent = parentObj.transform;
                break;

            case 7:
                Instantiate(orescript.orevein[7], transform.position, Quaternion.identity);
                gameObject.transform.parent = parentObj.transform;
                break;

            case 8:
                Instantiate(orescript.orevein[8], transform.position, Quaternion.identity);
                gameObject.transform.parent = parentObj.transform;
                break;

            case 9:
                Instantiate(orescript.orevein[9], transform.position, Quaternion.identity);
                gameObject.transform.parent = parentObj.transform;
                break;

            default:
                Debug.Log("Nothing to instantie into this orevein object");
                break;
        }
    }
}
