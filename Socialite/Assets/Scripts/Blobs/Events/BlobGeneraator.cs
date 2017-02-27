using UnityEngine;
using System.Collections.Generic;
using System;

public class BlobGeneraator : MonoBehaviour {

    [SerializeField]
    private float spawnRate= 5f;
    [SerializeField]
    private Transform[] spawnPosition;
    [Serializable]
    public struct Sprites { public string name; public float speedToward; public float speedAway; public Sprite sprite; }

    public Sprites[] spriteColor;

    private float countdown;
    private Colors[] colors;
    
    private List<GameObject> childList;
    private Dictionary<string, Sprite> colorList;
    private Dictionary<string, float> colorSpeedToward;
    private Dictionary<string, float> colorSpeedAway;

    void Start()
    {
        countdown = Time.time + spawnRate;

        colors = (Colors[])Enum.GetValues(typeof(Colors));

        childList = new List<GameObject>();
        colorList = new Dictionary<string, Sprite>();
        colorSpeedAway = new Dictionary<string, float>();
        colorSpeedToward = new Dictionary<string, float>();

        foreach (Transform t in transform)
            childList.Add(t.gameObject);

        foreach(Sprites sc in spriteColor)
        {
            colorList.Add(sc.name, sc.sprite);
            colorSpeedAway.Add(sc.name, sc.speedAway);
            colorSpeedToward.Add(sc.name, sc.speedToward);
        }
    }

    void Update()
    {
        if( countdown < Time.time)
        {
            Spawn();
            countdown = Time.time + spawnRate;
        }
    }

    private void Spawn()
    {
        if (childList.Count <= 0)
            return;

        GameObject child = childList[0];
        Blob blob = child.GetComponent<Blob>();
        SpriteRenderer sr = child.GetComponent<SpriteRenderer>();

        Colors colorPick = colors[UnityEngine.Random.Range(0, colors.Length)];
        blob.SetColor(colorPick);
        blob.SetAwaySpeed(colorSpeedAway[colorPick.ToString().ToLower()]);
        blob.SetTowardSpeed(colorSpeedToward[colorPick.ToString().ToLower()]);
        sr.sprite = colorList[colorPick.ToString().ToLower()];//this need to be moved to blob.cs
        
        child.transform.position = new Vector2(UnityEngine.Random.Range(spawnPosition[0].position.x, spawnPosition[1].position.x), UnityEngine.Random.Range(spawnPosition[0].position.y, spawnPosition[1].position.y));
        
        child.SetActive(true);
        childList.RemoveAt(0);
    }


}
