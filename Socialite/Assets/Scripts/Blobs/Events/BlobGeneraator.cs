using UnityEngine;
using System.Collections.Generic;
using System;

public class BlobGeneraator : MonoBehaviour {

    [SerializeField]
    private float spawnRate= 5f;
    [SerializeField]
    private float decayLifeRateUponSpawn = 1f;
    [SerializeField]
    private float life = 5f;

    [Serializable]
    public struct Sprites { public string name; public Sprite sprite; }

    public Sprites[] spriteColor;

    private float countdown;
    private Colors[] colors;
    private List<Transform> spawnPosition;
    private List<GameObject> childList;
    private Dictionary<string, Sprite> colorList;
    void Start()
    {
        countdown = Time.time + spawnRate;

        colors = (Colors[])Enum.GetValues(typeof(Colors));

        spawnPosition = new List<Transform>();
        childList = new List<GameObject>();
        colorList = new Dictionary<string, Sprite>();

        foreach (GameObject obj in  GameObject.FindGameObjectsWithTag("SpawnAI"))
        {
            spawnPosition.Add(obj.transform);
        }

        foreach (Transform t in transform)
            childList.Add(t.gameObject);

        foreach(Sprites sc in spriteColor)
        {
            colorList.Add(sc.name, sc.sprite);
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

        int randomPosition = UnityEngine.Random.Range(0, spawnPosition.Count);

        GameObject child = childList[0];
        Blob blob = child.GetComponent<Blob>();
        SpriteRenderer sr = child.GetComponent<SpriteRenderer>();

        Colors colorPick = colors[UnityEngine.Random.Range(0, colors.Length)];
        blob.SetColor(colorPick);
        sr.sprite = colorList[colorPick.ToString().ToLower()];//this need to be moved to blob.cs
        
        child.transform.position = spawnPosition[randomPosition].position;
        blob.SetLifeDecay(decayLifeRateUponSpawn);
        blob.SetLife(life);
        
        child.SetActive(true);
        childList.RemoveAt(0);
    }


}
