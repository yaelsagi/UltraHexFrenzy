using UnityEngine;
using System.Collections;

public class ScoreScreen : MonoBehaviour 
{
	private const float MIN_SHOW_TIME = 2f;
	public TextMesh score1;
	public TextMesh score2;
	public GameObject winner1;
	public GameObject winner2;
	public SplashScreen splash;

	void OnMouseDown() 
	{
		gameObject.SetActive(false);
		splash.play();
	}

	public void play(int s1, int s2)
	{
		collider2D.enabled=false;
		gameObject.SetActive(true);
		score1.text = ""+s1;
		score2.text = ""+s2;
		winner1.SetActive(s1>=s2);
		winner2.SetActive(s2>=s1);
		Invoke("enableLeave",MIN_SHOW_TIME);
	}

	private void enableLeave()
	{
		collider2D.enabled=true;
	}
}
