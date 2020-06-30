using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtons : MonoBehaviour {

	private bool isSelected;
	// Use this for initialization
	void Start () {
		isSelected = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		if (transform.name == "Options") {
			Vector3 scale = new Vector3 (1.15f, 1.0f, 1.0f);
			gameObject.transform.localScale = scale;
			Application.LoadLevel ("Options");
		} else if (transform.name == "Play") {
			Vector3 scale = new Vector3 (1.00f, 1.05f, 1.0f);
			gameObject.transform.localScale = scale;
			Application.LoadLevel ("Game");
		} else if (transform.name == "Back") {
			Vector3 scale = new Vector3 (1.05f, 1.00f, 1.0f);
			gameObject.transform.localScale = scale;
			Application.LoadLevel ("Menu");
		} else if (transform.name == "Quit") {
			Debug.Log ("Exited");
			Application.Quit ();
		} else if (transform.name == "Info") {
			Vector3 pos = new Vector3 (0.0f, 1.01f, -5.0f);
			GameObject.Find ("Board").transform.localPosition = pos;
		} else if (transform.name == "Return") {
			Vector3 pos = new Vector3 (-17.0f, 1.01f, -5.0f);
			GameObject.Find ("Board").transform.localPosition = pos;
		}
	}
}
