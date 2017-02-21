using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CircleCollider2D))]
public class CloseAura : MonoBehaviour {


    [SerializeField]
    private float lifeDecayEnter = 1f;
    [SerializeField]
    private float lifeDecayExit = 0f;

    private PlayerStatus status;

    void Start()
    {
        GetComponent<CircleCollider2D>().isTrigger = true;
        GameObject player = GameObject.FindWithTag("Player");
        status = player.GetComponent<PlayerStatus>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("AI"))
        {
            status.SetDecayRate(lifeDecayEnter);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("AI"))
        {
            status.SetDecayRate(lifeDecayExit);
        }
    }
}
