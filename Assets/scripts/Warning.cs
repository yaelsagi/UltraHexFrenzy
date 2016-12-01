using UnityEngine;
using System.Collections;

public class Warning : MonoBehaviour {
	void Update() 
	{
		if(Input.GetMouseButton(0))
		{
			Application.LoadLevel(1);
		}
	}
}
