using UnityEngine;
using System.Collections;

public enum Colors { Red, Blue, Green}
public enum ColorHate { Red, Blue, Green }
public enum ColorFavorite { Red, Blue, Green }

[RequireComponent(typeof(Rigidbody2D))]
public class Blob : MonoBehaviour {

    [SerializeField]
    private Colors blobColor;
    [SerializeField]
    private ColorHate colorHate;
    [SerializeField]
    private ColorFavorite colorFavorite;
    [SerializeField]
    private float speed = 2f;
    [SerializeField]
    private float life = 5f;
    [SerializeField]
    private float decayRate = 0f;

    private Rigidbody2D targetCharacter;

    private PlayerColor playerColor;

    private AbstractBlob blob;

    private Rigidbody2D rb;

	void Start () {
        GameObject player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        playerColor = player.GetComponent<PlayerColor>();
        targetCharacter = player.GetComponent<Rigidbody2D>();

        blob = new AbstractBlobFactory().GetBlob(blobColor.ToString());

        blob.HateColor = FindColor(colorHate.ToString());
        blob.FavoriteColor = FindColor(colorFavorite.ToString());
        blob.Speed = speed;
        blob.Life = life;

	}
	
	void FixedUpdate()
    {
        if(blob.Life != 0)
        {
            blob.Life -= decayRate;
            Vector2 velocity = blob.MovePos(rb.position, targetCharacter.position, playerColor.GetColor());
            rb.MovePosition( velocity );

        }



    }


    public Colors GetColors()
    {
        return blobColor;
    }

    public void SetColor(Colors color)
    {
        this.blobColor = color;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public void SetLifeDecay(float decayRate)
    {
        this.decayRate = decayRate;
    }

    //temporary leaving this function here
    private Color FindColor(string color)
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
}
