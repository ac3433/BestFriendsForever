using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class BlobGeneraator : MonoBehaviour {

    [SerializeField]
    private float spawnRate= 5f;

    private Colors[] colors;
    private List<Transform> spawnPosition;
    private List<GameObject> childList;
    void Start()
    {
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
        

    }

}
