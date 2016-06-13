using UnityEngine;
using System.Collections;

public class OreSweeper : MonoBehaviour {

	Collider col;
	public bool canSweep = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyUp ("up")) 
		{
			//enable sweeper
		} else if (Input.GetKeyUp ("down"))
			{
				//disable sweeper
			}

		//left key pressed is canSweep

		if(Input.GetMouseButtonDown(0) && canSweep)
		{
			//sweep nearby ores

		}
	}



}
