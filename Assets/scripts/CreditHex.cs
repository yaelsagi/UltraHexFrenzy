using UnityEngine;
using System.Collections;

public class CreditHex : MonoBehaviour {

	public GameObject CreditHeartHex;
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() 
	{
//		renderer.enabled=false;
		gameObject.SetActive(false);
		CreditHeartHex.SetActive(true);

	}
}
