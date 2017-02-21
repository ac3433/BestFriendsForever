using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class CloseAura : MonoBehaviour {



	void Start () {
        GetComponent<Collider2D>().isTrigger = true;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag.Equals("AI"))
        {
            
        }
    }
}
