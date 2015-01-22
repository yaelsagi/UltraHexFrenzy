using UnityEngine;
using System.Collections;

public class ScoreScreen : MonoBehaviour 
{
	public TextMesh score1;
	public TextMesh score2;
	public SplashScreen splash;

	void OnMouseDown() 
	{
		gameObject.SetActive(false);
		renderer.enabled=false;
		collider2D.enabled=false;
		splash.play();
	}

	public void play(int s1, int s2)
	{
		gameObject.SetActive(true);
		score1.text = ""+s1;
		score2.text = ""+s2;
		renderer.enabled=true;
		collider2D.enabled=true;
	}
}
