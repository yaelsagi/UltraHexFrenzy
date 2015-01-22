using UnityEngine;
using System.Collections;

public class Spark : MonoBehaviour {

	public const float ACTION_TIME = .5f;
	private Vector3 targetPos;
	private Vector3 startPos;
	private float timeLeft;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (timeLeft > 0)
		{
			float part = timeLeft / ACTION_TIME;
			transform.position = targetPos + (startPos - targetPos) * part;
			transform.localScale = new Vector3(part,part,part);

			timeLeft -= Time.deltaTime;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public void init(Vector3 start, Vector3 target)
	{
		renderer.enabled = true;
		startPos = start;
		timeLeft = ACTION_TIME;
		targetPos = target;
	}
}
