using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CircleCollider2D))]
public class CloseAura : MonoBehaviour {


    [SerializeField]
    private float scoreTimer = 1f;

    private PlayerStatus status;

    void Start()
    {
        GetComponent<CircleCollider2D>().isTrigger = true;
        GameObject player = GameObject.FindWithTag("Player");
        status = player.GetComponent<PlayerStatus>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        
    }
}
