﻿using UnityEngine;
using System.Collections;

public class DestroyThisObjectScript : MonoBehaviour {



	// Use this for initialization
	void Start () {



	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter (Collision coll){

		Destroy (gameObject);

		if (coll.gameObject.tag == "Wallpart") {
			Destroy (gameObject);
		}

	}

}
