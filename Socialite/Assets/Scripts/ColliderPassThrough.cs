using UnityEngine;
using System.Collections;

public class ColliderPassThrough : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D ai){
		if (ai.gameObject.tag == "AI") {
			ColorChanger.isInPlayerRadius = true;
		}
	}

}
