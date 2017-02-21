using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerStatus : MonoBehaviour {

    [SerializeField]
    private float health = 5f;
    [SerializeField]
    private float decayRate = 0f;

    private Color color;

    public Sprite[] sprite;
    private int colorPos = 0;

    void Start()
    {
        color = Color.blue;
    }
	
    //very lazy programming here
	void Update ()
    {
        if(Input.GetMouseButtonDown(0))
        {
            colorPos++;
            if (colorPos >= sprite.Length)
                colorPos = 0;
        }
        else if (Input.GetMouseButtonDown(1))
        {
            colorPos--;
            if (colorPos < 0)
                colorPos = sprite.Length -1;

        }

        if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            if (colorPos == 0)
                color = Color.blue;
            else if (colorPos == 1)
                color = Color.green;
            else if (colorPos == 2)
                color = Color.red;
            GetComponent<SpriteRenderer>().sprite = sprite[colorPos];
        }

	    if(health > 0)
        {
            health -= decayRate * Time.fixedDeltaTime;

        }
        else
        {
            GetComponent<PlayerController>().enabled = false;
            enabled = false;
        }
	}

    public Color GetColor()
    {
        return color;
    }

    public float GetHealth()
    {
        return health;
    }

    public void SetDecayRate(float rate)
    {
        decayRate = rate;
    }

}
