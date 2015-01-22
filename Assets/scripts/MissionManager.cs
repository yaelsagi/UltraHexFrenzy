using UnityEngine;
using System.Collections;

public class MissionManager : MonoBehaviour {

	private const float LEVEL_TIME = 10;

	private static MissionManager instance;
	public SpriteRenderer Player1;
	private int Score1;
	public SpriteRenderer Player2;
	private int Score2;
	public GameObject[] Levels;
	private Component[] sprites;
	private int level;
	public GameHex[] GameHexes;

	// Use this for initialization
	void Start () 
	{
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void Init()
	{
		instance.init();
	}
	
	public void init()
	{

		foreach (GameHex hex in GameHexes)
			hex.init();
		
		level=0;
		sprites = Levels[level].GetComponentsInChildren<SpriteRenderer>();
		Invoke("nextLevel",LEVEL_TIME);//"Invoke" calls the function/methud that is inside the(""), the number is the number of secends before it das that.
	}
	
	public static Sprite RandomImage()
	{
		return ((SpriteRenderer)instance.sprites[Random.Range(0,instance.sprites.Length)]).sprite;
	}

	private void nextLevel()
	{
		level++;
		sprites = Levels[level].GetComponentsInChildren<SpriteRenderer>();

		if(level > Levels.Length)
			Levelend();
		else
			instance.Invoke("nextLevel",3);
	}


	private void Levelend()
	{
		foreach (GameHex hex in GameHexes)
			hex.end();
	}

	public static void Pressed(Sprite sprite)
	{
		instance.pressed(sprite);
	}

	private void pressed(Sprite sprite)
	{
		if (Player1.sprite == sprite)
			Score1++;
		if(Player2.sprite == sprite)
			Score2++;
	}
}
