using UnityEngine;
using System.Collections;

public class MissionManager : MonoBehaviour {

	private static MissionManager instance;
	public GameObject Player1;
	public GameObject Player2;
	public GameObject[] Levels;
	private int level;
	public GameObject[] GameHexes;

	// Use this for initialization
	void Start () 
	{
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	static public void Init()
	{
		// GameHexes[all].init();

		instance.level=0;
		instance.Invoke("nextLevel",3);//"Invoke" calls the function/methud that is inside the(""), the number is the number of secends before it das that.
	}

	static public Sprite getRandomImage()
	{

	}

	private void nextLevel()
	{
		level++;
		instance.Invoke("nextLevel",3);

		//if level end
	}


	private void Levelend()
	{
		//GameHexes[all].end()
	}


}
