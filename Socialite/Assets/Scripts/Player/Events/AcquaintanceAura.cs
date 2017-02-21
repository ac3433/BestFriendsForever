using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CircleCollider2D))]
public class AcquaintanceAura : MonoBehaviour {

    [SerializeField]
    private float lifeDecayEnter = 0f;
    [SerializeField]
    private float lifeDecayExit = 1f;
    [SerializeField]
    private float healthRegen = 1f;


	void Start () {
        GetComponent<CircleCollider2D>().isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("AI"))
        {
            Blob blob = other.gameObject.GetComponent<Blob>();
            blob.SetLifeDecay(lifeDecayEnter);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("AI"))
        {
            Blob blob = other.gameObject.GetComponent<Blob>();
            blob.SetLifeDecay(lifeDecayExit);
            blob.SetHealthRegen(0);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("AI"))
        {
            Blob blob = other.gameObject.GetComponent<Blob>();
            blob.SetHealthRegen(healthRegen);
        }
    }
}
