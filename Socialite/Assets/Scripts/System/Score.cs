using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Score : MonoBehaviour {
    [Serializable]
    public struct ColorScore { public string name; public float multiplier; }

    
    public ColorScore[] scoreValue;

    private float score;

    private Dictionary<string, float> multipler;

    public UnityEngine.UI.Text text;//feeling lazy

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
        text.text = string.Format("Score: {0}", score);
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
