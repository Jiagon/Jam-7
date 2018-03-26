using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class color_enemy : MonoBehaviour {

	public int color; //0=red; 1=blue; 2=green;
	public Material red;
	public Material blue;
	public Material green;

	// Use this for initialization
	void Start () {
		if(color == 0)
			GetComponent<Renderer> ().material = red;
		else if(color == 1)
			GetComponent<Renderer> ().material = blue;
		else if(color == 2)
			GetComponent<Renderer> ().material = green;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col){

		if (col.gameObject.name == "red") {
			Destroy (col.gameObject);
			if (color == 0) {
				Debug.Log ("red killed me");
				Destroy (this.gameObject);
			}
		}
		else if (col.gameObject.name == "blue") {
			Destroy (col.gameObject);
			if (color == 1) {
				Debug.Log ("blue killed me");
				Destroy (this.gameObject);
			}
		}
		else if (col.gameObject.name == "green") {
			Destroy (col.gameObject);
			if (color == 2) {
				Debug.Log ("green killed me");
				Destroy (this.gameObject);
			}
		}
	
	}
}
