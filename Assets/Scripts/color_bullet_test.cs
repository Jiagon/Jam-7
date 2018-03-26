using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class color_bullet_test : MonoBehaviour {

	public Material red;
	public Material blue;
	public Material green;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyUp (KeyCode.W)) {
			//Debug.Log ("Pressed W");
			//spawn red bullet at this.position.
			GameObject bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			bullet.name = "red";
			bullet.transform.position = this.transform.position;
			bullet.GetComponent<Renderer> ().material = red;
			bullet.AddComponent<color_bullet> ();
			bullet.AddComponent<Rigidbody> ();
			bullet.GetComponent<Rigidbody> ().useGravity = false;

		}
		else if (Input.GetKeyUp (KeyCode.E)) {
			//Debug.Log ("Pressed E");
			//spawn blue bullet at this.position.
			GameObject bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			bullet.name = "blue";
			bullet.transform.position = this.transform.position;
			bullet.GetComponent<Renderer> ().material = blue;
			bullet.AddComponent<color_bullet> ();
			bullet.AddComponent<Rigidbody> ();
			bullet.GetComponent<Rigidbody> ().useGravity = false;
		}
		else if (Input.GetKeyUp (KeyCode.R)) {
			//Debug.Log ("Pressed R");
			//spawn green bullet at this.position.
			GameObject bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			bullet.name = "green";
			bullet.transform.position = this.transform.position;
			bullet.GetComponent<Renderer> ().material = green;
			bullet.AddComponent<color_bullet> ();
			bullet.AddComponent<Rigidbody> ();
			bullet.GetComponent<Rigidbody> ().useGravity = false;
		}



	}
}
