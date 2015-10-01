using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManagerScript : MonoBehaviour {

	public Text oreText;
	public Text brickText;
	public string ore, brick;
	public int oreAmount, brickAmount;
	public GameObject UICanvas;

	void Awake(){
		//oreText = UICanvas.GetComponentInChildren<Text>();
		//brickText = UICanvas.GetComponentInChildren<Text>();
	}


	// Use this for initialization
	void Start () {
		brickAmount = 55;
		oreAmount = 0;

		ore = "Ores * ";
		brick = "Bricks * ";

		//oreText.text = ;
		//brickText.text = ore + oreAmount.ToString () +brick + brickAmount.ToString ();

		oreText.text = ore + oreAmount.ToString() ;
		brickText.text = brick + brickAmount.ToString ();


		
	}
	
	// Update is called once per frame
	void Update () {

		if (oreAmount < 0) {
			oreAmount = 0;
		}
	}

	public void CurrentOreCount(){
		oreText.text = ore + oreAmount.ToString ();
		brickText.text = brick + brickAmount.ToString ();
	}
}
