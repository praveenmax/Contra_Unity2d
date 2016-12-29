using UnityEngine;
using System.Collections;
/*
*
* Author : PraveenMax
*/

public class mainmenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		Application.LoadLevel("scene1");
		//Debug.Log ("clicked");

	}
}
