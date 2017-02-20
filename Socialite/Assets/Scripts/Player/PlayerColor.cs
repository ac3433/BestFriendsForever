using UnityEngine;
using System.Collections;

public class PlayerColor : MonoBehaviour {

    private Color color ;

	void Start () {
        color = Color.blue;

    }
	
    //to be modify to change it's color
	void Update () {
	
	}


    public Color GetColor()
    {
        return color;
    }
}
