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

    private float countdown;
    private Colors[] colors;
    private List<Transform> spawnPosition;
    private List<GameObject> childList;
    void Start()
    {
        countdown = Time.time + spawnRate;

        colors = (Colors[])Enum.GetValues(typeof(Colors));

        spawnPosition = new List<Transform>();
        childList = new List<GameObject>();

        foreach(GameObject obj in  GameObject.FindGameObjectsWithTag("SpawnAI"))
        {
            spawnPosition.Add(obj.transform);
        }

        foreach (Transform t in transform)
            childList.Add(t.gameObject);

        
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

        var colors = (Colors[])Enum.GetValues(typeof(Colors));
        Colors colorPick = colors[UnityEngine.Random.Range(0, colors.Length)];
        blob.SetColor(colorPick);

        child.transform.position = spawnPosition[randomPosition].position;
        blob.SetLifeDecay(decayLifeRateUponSpawn);
        blob.SetLife(life);
        
        child.SetActive(true);
        childList.RemoveAt(0);
    }


}
