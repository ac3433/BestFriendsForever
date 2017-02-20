using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed;

	Rigidbody2D r2D;

	// Use this for initialization
	void Start () {
		r2D = GetComponent<Rigidbody2D> ();	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) {
			Vector2 upMovement = new Vector2 (0, speed);
			r2D.AddForce (upMovement);
		}
		if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow)) {
			Vector2 downMovement = new Vector2 (0, -speed);
			r2D.AddForce (downMovement);
		}
		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
			Vector2 leftMovement = new Vector2 (-speed, 0);
			r2D.AddForce (leftMovement);
		}
		if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
			Vector2 rightMovement = new Vector2 (speed, 0);
			r2D.AddForce (rightMovement);
		}
	}
}
