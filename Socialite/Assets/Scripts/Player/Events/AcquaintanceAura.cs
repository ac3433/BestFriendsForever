using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(CircleCollider2D))]
public class AcquaintanceAura : MonoBehaviour {

    private List<GameObject> objsInCircle;

    void Start () {
        objsInCircle = new List<GameObject>();
        GetComponent<CircleCollider2D>().isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("AI"))
        {
            Blob blob = other.gameObject.GetComponent<Blob>();
            blob.enabled = true;

            if (!objsInCircle.Contains(other.gameObject))
                objsInCircle.Add(other.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("AI"))
        {
            Blob blob = other.gameObject.GetComponent<Blob>();
            blob.enabled = false;

            if (objsInCircle.Contains(other.gameObject))
                objsInCircle.Remove(other.gameObject);
        }
    }

    //void OnTriggerStay2D(Collider2D other)
    //{
    //    if (other.gameObject.tag.Equals("AI"))
    //    {
    //        Blob blob = other.gameObject.GetComponent<Blob>();
    //    }
    //}

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
        foreach (GameObject obj in objsInCircle)
        {
            Blob b = obj.GetComponent<Blob>();
            if (!b.GetColor().Equals(color))
                o.Add(obj);
        }

        return o;
    }

    //these below is terrible
    public int CountFilterColor(Color color)
    {
        return FilterColorGameObject(color).Count;
    }

    public GameObject GetFilterObj(Color color, int pos)
    {
        return FilterColorGameObject(color)[pos];
    }
}
