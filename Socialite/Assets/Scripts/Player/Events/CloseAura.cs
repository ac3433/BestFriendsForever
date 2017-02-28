using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(CircleCollider2D), typeof(Score))]
public class CloseAura : MonoBehaviour {


	[SerializeField]
	private float scoreTimer = 10f;

	private PlayerStatus status;
	private List<GameObject> objsInCircle;
	private List<GameObject> colorObj;

	[HideInInspector]
	public float countdown = 0;
	private Score score;

	void Start()
	{
		GetComponent<CircleCollider2D>().isTrigger = true;
		GameObject player = GameObject.FindWithTag("Player");
		status = player.GetComponent<PlayerStatus>();
		score = GetComponent<Score>();
		objsInCircle = new List<GameObject>();

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
			List<GameObject> colorObj = FilterColorGameObject(status.GetColor());

			if(colorObj.Count != 0)
			{
				countdown += Time.fixedDeltaTime;
				if(countdown > scoreTimer)
				{
					score.ScoreIt(colorObj.Count, status.GetColor());
					foreach(GameObject obj in colorObj)
					{
						obj.transform.position = new Vector2(-38, 0);
						obj.SetActive(false);
					}
					countdown = 0f;
				}
			}
			else
			{
				countdown = 0;
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
		foreach (GameObject obj in objsInCircle)
		{
			Blob b = obj.GetComponent<Blob>();
			if (b.GetColor().Equals(color))
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
