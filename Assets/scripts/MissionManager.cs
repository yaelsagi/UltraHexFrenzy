using UnityEngine;
using System.Collections;

public class MissionManager : MonoBehaviour {

	private static MissionManager instance;
	public GameObject Player1;
	public GameObject Player2;
	public GameObject[] levels;
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
		//instance.
	}
}
