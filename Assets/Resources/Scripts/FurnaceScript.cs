using UnityEngine;
using System.Collections;

public class FurnaceScript : MonoBehaviour {

	private bool canMelt;
	public GameObject meltingChunk;
	private Vector3 oreFallpos;

	public GameObject addOre;
	UIManagerScript uiscript;
	
	
	void Awake(){
		addOre = GameObject.Find("UIManager");
		uiscript = addOre.GetComponent<UIManagerScript> ();
	}

	// Use this for initialization
	void Start () {
		canMelt = false;
		oreFallpos.y = gameObject.transform.position.y + 2.5f;
		oreFallpos.x = gameObject.transform.position.x;
		oreFallpos.z = gameObject.transform.position.z;

		oreFallpos = new Vector3(oreFallpos.x, oreFallpos.y, oreFallpos.z);
		Debug.Log (oreFallpos);
	}
	
	// Update is called once per frame
	void Update () {
		if (canMelt && uiscript.oreAmount > 0) {
			UseOre();
		}
	}

	void OnMouseEnter() {
		canMelt = true;
	}
	
	void OnMouseExit() {
		canMelt = false;
	}

	void UseOre(){

		if (Input.GetMouseButtonDown(0) && canMelt == true) {
			Instantiate (meltingChunk, oreFallpos, Quaternion.identity);

			uiscript.oreAmount-- ;
			uiscript.CurrentOreCount();
		}
	}

	void MeltingToBrick(){



	}
}
