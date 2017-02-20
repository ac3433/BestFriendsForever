using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMotor : MonoBehaviour {

    private Vector2 velocity = Vector2.zero;

    private Rigidbody2D rb;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate()
    {
        PerformMovement();
    }

    void PerformMovement()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);

    }

    public void Move(Vector2 velocity)
    {
        this.velocity = velocity;

    }
}
