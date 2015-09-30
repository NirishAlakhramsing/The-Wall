using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManagerScript : MonoBehaviour {

	public Text oreText;
	private string ore;
	public int oreAmount, brickAmount;
	public GameObject UICanvas;

	void Awake(){
		oreText = UICanvas.GetComponentInChildren<Text> ();
	}


	// Use this for initialization
	void Start () {
		brickAmount = 55;

		ore = "Ore = ";
		oreAmount = 0;
		oreText.text = ore + oreAmount.ToString ();

		Debug.Log (oreText.text);



	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (brickAmount);
		if (oreAmount < 0) {
			oreAmount = 0;
		}


	}

	public void CurrentOreCount(){
		oreText.text = ore + oreAmount.ToString ();
	}
}
