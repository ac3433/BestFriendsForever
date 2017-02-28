using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(CircleCollider2D), typeof(Score))]
public class CloseAura : MonoBehaviour {


    [SerializeField]
    private float scoreTimer = 1f;

    private PlayerStatus status;
    private List<GameObject> objsInCircle;

    private float countdown = 0;
    private Score score;

    void Start()
    {
        GetComponent<CircleCollider2D>().isTrigger = true;
        GameObject player = GameObject.FindWithTag("Player");
        status = player.GetComponent<PlayerStatus>();
        score = player.GetComponent<Score>();
        objsInCircle = new List<GameObject>();

        countdown = Time.time + scoreTimer;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag.Equals("AI"))
        {
            if (!objsInCircle.Contains(other.gameObject))
                objsInCircle.Add(other.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.Equals("AI"))
        {
            if (objsInCircle.Contains(other.gameObject))
                objsInCircle.Remove(other.gameObject);
        }
    }

    //would move this somewhere else. Waste of resource in running and a logical flaw
    void Update()
    {
        if (objsInCircle.Count != 0)
        {
            if (objsInCircle[0].GetComponent<Blob>().GetColor().Equals(status.GetColor()))
            {
                if (countdown < Time.time)
                {

                    countdown = Time.time + scoreTimer;
                }
            }
            else
            {
                countdown = 0f;
                objsInCircle.Clear();
            }
        }
        else
            countdown = 0f;
    }

    public GameObject GetGameObjectInCircle(int pos)
    {
        return objsInCircle[pos];
    }

    public int GetGameObjectsCount()
    {
        return objsInCircle.Count;
    }

    public List<GameObject> FilterColorGameObject(Color color)
    {
        List<GameObject> o = new List<GameObject>();
        foreach(GameObject obj in objsInCircle)
        {
            Blob b = obj.GetComponent<Blob>();
            if (!b.GetColor().Equals(color))
                o.Add(obj);
        }

        return o;
    }
}
