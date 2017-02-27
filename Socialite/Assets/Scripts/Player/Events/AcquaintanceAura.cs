using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CircleCollider2D))]
public class AcquaintanceAura : MonoBehaviour {

	void Start () {
        GetComponent<CircleCollider2D>().isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("AI"))
        {
            Blob blob = other.gameObject.GetComponent<Blob>();
            blob.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("AI"))
        {
            Blob blob = other.gameObject.GetComponent<Blob>();
            blob.enabled = false;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("AI"))
        {
            Blob blob = other.gameObject.GetComponent<Blob>();
        }
    }
}
