using UnityEngine;
using System.Collections;


[RequireComponent (typeof (SpriteRenderer))]
public class GameHex : MonoBehaviour {

	private const float MAX_WAIT = 3f;
	private const int VISBLE_TIME = 3;
	private bool HexIsHere=false;
	private bool TouchedHex=false;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
//		gameObject.tag = "laserhittag"; 
//		if(TouchedHex=true)
//		{
//			foreach (Touch touch in Input.touches)
//			{
	//			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position),Vector2.zero);
			 
//				if (hit.collider.tag == "GameHex")
//				{
//					MissionManager.Pressed(GetComponent<SpriteRenderer>());
//					CancelInvoke();
//					disappear();
//					Invoke("appear", Random.Range(0,MAX_WAIT));
//					TouchedHex=false;
//				}
//			}
	//	}

//		int i = 0;
//		while (i < Input.touchCount)
	//	{
	//		if (Input.GetTouch(i).phase == TouchPhase.Began)
	//		{
	//			var hit : RaycastHit;
	//			var ray : Ray = camera.ScreenPointToRay(Vector3(Touch.x,Touch.y,0));
	//			if(physics.Raycast(ray, hit) && hit.transform.tag == "selectable")

	//		}

	//		++i;
//		}
			

	}

	private void appear()
	{
		animation.Play("GameHexAppear");
		HexIsHere=true;
		GetComponent<SpriteRenderer>().sprite = MissionManager.RandomImage();
		Invoke("disappear", VISBLE_TIME);
		Invoke("appear", VISBLE_TIME + Random.Range(0,MAX_WAIT));
	}
	
	private void disappear()
	{
		HexIsHere=false;
		animation.Play("GameHexDisappear");
	}
	
	public void init()
	{
		renderer.enabled = true;
		//disappear();
		CancelInvoke();
		Invoke("appear", Random.Range(0f,MAX_WAIT));
	}
	
	public void end()
	{
		CancelInvoke();
		disappear();
		renderer.enabled = false;
	}

	void OnMouseDown() 
	{
////////		if (renderer.enabled)
		if(HexIsHere&&!animation["GameHexDisappear"].enabled)
		{
			MissionManager.Pressed(GetComponent<SpriteRenderer>());
			CancelInvoke();
			disappear();
			Invoke("appear", Random.Range(0,MAX_WAIT));
//			TouchedHex=true;
		}
	}
}
