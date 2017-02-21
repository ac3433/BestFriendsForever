using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {

    [SerializeField]
    private float health = 5f;

    private Color color;

    void Awake()
    {
        color = Color.blue;
    }

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Color GetColor()
    {
        return color;
    }


}
