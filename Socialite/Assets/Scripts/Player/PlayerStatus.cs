using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerStatus : MonoBehaviour {

    private Color color;

    public Sprite[] sprite;
    private int colorPos = 0;

    private CloseAura aura;

    void Start()
    {
        color = Color.blue;
        aura = GameObject.Find("Player/Close-Aura").GetComponent<CloseAura>();
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

	}

    public Color GetColor()
    {
        return color;
    }

    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    if(other.gameObject.tag.Equals("AI"))
    //    {
    //        Blob blob = other.gameObject.GetComponent<Blob>();

    //        if(blob.GetColor().Equals(Color.red) && color.Equals(Color.red))
    //        {
    //            List<GameObject> o = aura.FilterColorGameObject(Color.red);

    //            foreach(GameObject obj in o)
    //            {
    //                Blob ai = obj.GetComponent<Blob>();
    //                ai.ForceAway(true);
    //            }
    //        }
    //    }
    //}

}
