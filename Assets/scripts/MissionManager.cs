using UnityEngine;
using System.Collections;

public class MissionManager : MonoBehaviour {

	public ScoreScreen scores;
	public SpriteRenderer Player1;
	private int Score1;
	public SpriteRenderer Player2;
	private int Score2;
	public Level[] Levels;
	private Component[] sprites;
	private int level;
	public GameHex[] GameHexes;
	private bool running = false;
	public AudioSource missionSwitch;
	public Spark spark;
	public GameObject ColorfullLightsUp;
	public GameObject ColorfullLightsDown;

	// Static access
	private static MissionManager instance;
	public static void Init(){instance.init();}
	public static Sprite RandomImage(){return instance.randomImage();}
	public static void Pressed(SpriteRenderer hex){instance.pressed(hex);}
	
	// Use this for initialization
	void Start () 
	{
		instance = this;
		foreach (GameHex hex in GameHexes)
			hex.end();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) 
		{
			if (running)
				endGame();
			else
				Application.Quit(); 
		}
	}

	public void init()
	{
		running = true;
		Score1 = 0;
		Score2 = 0;
		level=0;
		sprites = Levels[level].GetComponentsInChildren<SpriteRenderer>(true);

		Invoke("nextLevel",Levels[level].levelTime);//"Invoke" calls the function/methud that is inside the(""), the number is the number of secends before it das that.
		switchMissions();

		foreach (GameHex hex in GameHexes)
			hex.init();

		ColorfullLightsUp.SetActive(false);
		ColorfullLightsDown.SetActive(false);
	}

	public Sprite randomImage()
	{
		int index = Random.Range(0,sprites.Length);
		Sprite result = ((SpriteRenderer)sprites[index]).sprite;
		return result;
	}
	
	private void nextLevel()
	{
		level++;

		if(level == Levels.Length)
		{
			endGame();
			return;
		}

		sprites = Levels[level].GetComponentsInChildren<SpriteRenderer>(true);
		Invoke("nextLevel",Levels[level].levelTime);
	}

	
	private void endGame()
	{
		running = false;
		CancelInvoke();
		foreach (GameHex hex in GameHexes)
			hex.end();

		Player1.sprite = null;
		Player2.sprite = null;

		scores.play(Score1,Score2);
	}
	
	private void pressed(SpriteRenderer hex)
	{
		if (Player1.sprite == hex.sprite)
		{
			Score1+=Levels[level].scorePerHit;
			Spark ins =  (Spark)Instantiate(spark);
			ins.init(hex.transform.position,Player1.transform.position);
		}
		if(Player2.sprite == hex.sprite)
		{
			Score2+=Levels[level].scorePerHit;
			Spark ins =  (Spark)Instantiate(spark);
			ins.init(hex.transform.position,Player2.transform.position);
		}
	}

	private void switchMissions()
	{
		Sprite old1 = Player1.sprite;
		Sprite old2 = Player2.sprite;
		Player1.sprite = randomImage();
		Player2.sprite = randomImage();
		while (Player1.sprite == Player2.sprite)
			Player2.sprite = randomImage();
		if(old1 != null && old2 != null && (old1 != Player1.sprite || old2 != Player2.sprite))
		{
			missionSwitch.Play();

			if (old1 != Player1.sprite)
				ColorfullLightsUp.SetActive(true);
			if (old2 != Player2.sprite)
				ColorfullLightsDown.SetActive(true);

			Invoke("TernOffColorfullLights", 0.2f);
		}
		Invoke("switchMissions",Random.Range(Levels[level].missionMinTime,Levels[level].missionMaxTime));
	}

	
	private void TernOffColorfullLights()
	{
		ColorfullLightsUp.SetActive(false);
		ColorfullLightsDown.SetActive(false);
	}
}
