using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManagerScript : MonoBehaviour {

	public Text oreText;
	public Text brickText;
	public Text wallText;
	public Text endText;

	public string ore, brick, wall, win, lose;
	public int oreAmount, brickAmount, wallAmount;
	public GameObject UICanvas;

	void Awake(){
		//oreText = UICanvas.GetComponentInChildren<Text>();
		//brickText = UICanvas.GetComponentInChildren<Text>();
	}


	// Use this for initialization
	void Start () {
		endText.enabled = false;
		brickAmount = 55;
		oreAmount = 0;
		wallAmount = 100;

		wall = "Wall = ";
		ore = "Ores * ";
		brick = "Bricks * ";
		win = "You Win!!!";
		lose = "You Lose!!!";
		//oreText.text = ;
		//brickText.text = ore + oreAmount.ToString () +brick + brickAmount.ToString ();

		oreText.text = ore + oreAmount.ToString() ;
		brickText.text = brick + brickAmount.ToString ();
		wallText.text = wall + wallAmount.ToString ()+ "% ";
		
	}
	
	// Update is called once per frame
	void Update () {

		if (wallAmount <= 0) {
			endText.enabled= true;
			endText.text = lose;
			endText.color = Color.red;
		} else {
			endText.text = " ";
		}

		if (oreAmount < 0) {
			oreAmount = 0;
		}

		wallText.text = wall + wallAmount.ToString ();
	}

	public void CurrentOreCount(){
		oreText.text = ore + oreAmount.ToString ();
		brickText.text = brick + brickAmount.ToString ();
		wallText.text = wall + wallAmount.ToString ();
	}
}
