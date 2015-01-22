using UnityEngine;
using System.Collections;

[RequireComponent (typeof (SpriteRenderer))]
public class ScoreScreen : MonoBehaviour 
{
	private const float MIN_SHOW_TIME = 3f;
	public TextMesh score1;
	public TextMesh score2;
	public GameObject winner1;
	public GameObject winner2;
	public SplashScreen splash;

	public Sprite player1Won;
	public Sprite player2Won;
	public Sprite gameTie;
	public Sprite playAgain;

	void OnMouseDown() 
	{
		gameObject.SetActive(false);
		splash.play();
	}

	public void play(int s1, int s2)
	{

		if (s1 == s2)
			GetComponent<SpriteRenderer>().sprite = gameTie;
		else if (s1 > s2)
			GetComponent<SpriteRenderer>().sprite = player1Won;
		else 
			GetComponent<SpriteRenderer>().sprite = player2Won;


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
		GetComponent<SpriteRenderer>().sprite = playAgain;
		collider2D.enabled=true;
	}
}
