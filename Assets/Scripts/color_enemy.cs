using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class color_enemy : MonoBehaviour {

	public int color; //0=red; 1=blue; 2=green;
	//public Material red;
	//public Material blue;
	//public Material green;

	// Use this for initialization
	void Start () {
		//if(color == 0)
		//	GetComponent<Renderer> ().material.color = Color.red;
		//else if(color == 1)
		//	GetComponent<Renderer> ().material.color = Color.blue;
		//else if(color == 2)
		//	GetComponent<Renderer> ().material.color = Color.green;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col){

		if (col.gameObject.name == "red" && color == 0)
        {
            Destroy(col.gameObject);
			Destroy (this.gameObject);
			
		}
		else if (col.gameObject.name == "blue" && color == 1)
        {
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }
		else if (col.gameObject.name == "green" && color == 2)
        {
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }
		
	
	}
}
