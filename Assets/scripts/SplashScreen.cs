using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour 
{
	void OnMouseDown() 
	{
		renderer.enabled=false;
		collider2D.enabled=false;
		ActivatePlayersHexOnGameStart();
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void ActivatePlayersHexOnGameStart()
	{
		
	}
}
