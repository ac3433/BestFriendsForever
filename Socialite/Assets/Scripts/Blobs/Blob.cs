using UnityEngine;
using System.Collections;

public enum Colors { Red, Blue, Green}


[RequireComponent(typeof(Rigidbody2D))]
public class Blob : MonoBehaviour {

    [SerializeField]
    private Colors blobColor;
    [SerializeField]
    private float runAwaySpeed = 2f;
    [SerializeField]
    private float runTowardSpeed = 3f;

    private Rigidbody2D targetCharacter;

    private PlayerStatus playerStatus;

    private AbstractBlob blob;

    private Rigidbody2D rb;

    private float countdown;

	void Start () {
        GameObject player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        playerStatus = player.GetComponent<PlayerStatus>();
        targetCharacter = player.GetComponent<Rigidbody2D>();
        countdown = 5;
        blob = new AbstractBlobFactory().GetBlob(blobColor.ToString());
	}
	
	void FixedUpdate()
    {

        if (blob.MovingForward(playerStatus.GetColor()))
            blob.Speed = runTowardSpeed;
        else
            blob.Speed = runAwaySpeed;

        Vector2 velocity = blob.MovePos(rb.position, targetCharacter.position, playerStatus.GetColor());
        rb.MovePosition( velocity );

        //if(blob.ForceAway)
        //{
        //    if (countdown < 0)
        //    {
        //        blob.ForceAway = false;
        //        countdown = 5;
        //    }
        //    else
        //        countdown -= Time.fixedDeltaTime * 5;

        //}

    }


    public Colors GetColor()
    {
        return blobColor;
    }

    public void SetColor(Colors color)
    {
        this.blobColor = color;
        blob = new AbstractBlobFactory().GetBlob(blobColor.ToString());
    }

    public void SetTowardSpeed(float speed)
    {
        runTowardSpeed = speed;
    }
    public void SetAwaySpeed(float speed)
    {
        runAwaySpeed = speed;
    }

    //temporary leaving this function here
    public Color FindColor(string color)
    {
        if (color.ToLower().Equals("red"))
            return Color.red;
        if (color.ToLower().Equals("blue"))
            return Color.blue;
        if (color.ToLower().Equals("green"))
            return Color.green;
        else
            return Color.clear;

    }

    //public void ForceAway(bool away)
    //{
    //    blob.ForceAway = away;
    //}

}
