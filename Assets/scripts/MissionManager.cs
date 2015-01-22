using UnityEngine;
using System.Collections;

public class MissionManager : MonoBehaviour {

	private const float LEVEL_TIME = 10;

	public SpriteRenderer Player1;
	private int Score1;
	public SpriteRenderer Player2;
	private int Score2;
	public GameObject[] Levels;
	private Component[] sprites;
	private int level;
	public GameHex[] GameHexes;

	// Static access
	private static MissionManager instance;
	public static void Init(){instance.init();}
	public static Sprite RandomImage(){return instance.randomImage();}
	public static void Pressed(Sprite sprite){instance.pressed(sprite);}
	
	// Use this for initialization
	void Start () 
	{
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void init()
	{
		level=0;
		sprites = Levels[level].GetComponentsInChildren<SpriteRenderer>(true);
		Invoke("nextLevel",LEVEL_TIME);//"Invoke" calls the function/methud that is inside the(""), the number is the number of secends before it das that.

		foreach (GameHex hex in GameHexes)
			hex.init();
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
			Levelend();
			return;
		}

		sprites = Levels[level].GetComponentsInChildren<SpriteRenderer>(true);
		instance.Invoke("nextLevel",3);
	}
	
	private void Levelend()
	{
		foreach (GameHex hex in GameHexes)
			hex.end();
	}
	
	private void pressed(Sprite sprite)
	{
		if (Player1.sprite == sprite)
			Score1++;
		if(Player2.sprite == sprite)
			Score2++;
	}
}
