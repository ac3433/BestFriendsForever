using UnityEngine;
using System.Collections;

public class ColorChanger : MonoBehaviour {

	public Sprite defaultColor;
	public Sprite decaying;
	public static bool isInPlayerRadius; //That big'ol yellow sphere
	SpriteRenderer rend;

	// Use this for initialization
	void Start () {
		rend = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isInPlayerRadius) {
			rend.sprite = defaultColor;
		} else if(!isInPlayerRadius) {
			rend.sprite = decaying;
		}
	
	}

	void OnCollisionEnter2D (Collision2D c)
	{
		if (c.collider.tag == "Aura") {
			isInPlayerRadius = true;
		} else {
			isInPlayerRadius = false;
		}
			
	}
}
