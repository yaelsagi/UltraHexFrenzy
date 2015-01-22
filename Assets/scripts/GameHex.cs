using UnityEngine;
using System.Collections;


[RequireComponent (typeof (SpriteRenderer))]
public class GameHex : MonoBehaviour {

	private const float MAX_WAIT = 3f;
	private const int VISBLE_TIME = 3;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	private void appear()
	{
		renderer.enabled = true;
		GetComponent<SpriteRenderer>().sprite = MissionManager.RandomImage();
		Invoke("disappear", VISBLE_TIME);
		Invoke("appear", VISBLE_TIME + Random.Range(0,MAX_WAIT));
	}
	
	private void disappear()
	{
		renderer.enabled = false;
	}
	
	public void init()
	{
		disappear();
		CancelInvoke();
		Invoke("appear", Random.Range(0f,MAX_WAIT));
	}
	
	public void end()
	{
		CancelInvoke();
		disappear();
	}

	void OnMouseDown() 
	{
		if (renderer.enabled)
		{
			MissionManager.Pressed(GetComponent<SpriteRenderer>());
			CancelInvoke();
			disappear();
			Invoke("appear", Random.Range(0,MAX_WAIT));
		}
	}
}
