using UnityEngine;
using System.Collections;

public class CreateGrid : MonoBehaviour {

	public int gridSize = 10;

	// Create the cells 
	void Start () {
		for (int i = 0; i < gridSize; i++) {
			for (int j = 0; j < gridSize; j++) {
				GameObject plane;
				plane = GameObject.CreatePrimitive(PrimitiveType.Quad);
				plane.transform.position = new Vector3(+i*10,this.transform.position.y,j*10);
				plane.name = "cell" + i + j;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
