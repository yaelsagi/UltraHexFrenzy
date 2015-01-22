using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour 
{
	void OnMouseDown() 
	{
		renderer.enabled=false;
		collider2D.enabled=false;
		MissionManager.Init();
	}

	// Use this for initialization
	void Start () 
	{
		play();
	}
	
	public void play()
	{
		renderer.enabled=true;
		collider2D.enabled=true;
	}
}
