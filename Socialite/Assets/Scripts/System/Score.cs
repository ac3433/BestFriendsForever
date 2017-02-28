using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Score : MonoBehaviour {

	private struct ColorScore { public string name; public float multiplier; }

    [SerializeField]
    private ColorScore[] scoreValue;

    private float score;

    private Dictionary<string, float> multipler;

    void Start () {
        score = 0;
        multipler = new Dictionary<string, float>();

        foreach(ColorScore s in scoreValue)
        {
            multipler.Add(s.name, s.multiplier);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void ScoreIt(int number, Color color)
    {
        string c = ColorToString(color);

        if(c != null)
        {
            float multi = multipler[c];
            score += (multi * number);
        }
    }

    //to be moved to another class
    private string ColorToString(Color color)
    {
        if(color.Equals(Color.red))
        {
            return "red";
        }
        else if(color.Equals(Color.blue))
        {
            return "blue";
        }
        else if(color.Equals(Color.green))
        {
            return "green";
        }

        return null;
    }
}
