using UnityEngine;
using System.Collections;
/*
*
* Author : PraveenMax
*/

public class touchcontrols : MonoBehaviour {

	private GameObject go;
	private int nbTouches;

	// Use this for initialization
	void Start () {
		go = GameObject.Find("contra");
	}
	
	// Update is called once per frame
	void Update () {
		nbTouches = Input.touchCount;
		
		if(nbTouches!=0)
			touchProcessor ();
	}

	/*
	void OnMouseDrag()
	{
		playermovement other = (playermovement) go.GetComponent(typeof(playermovement));
		other.playerController(gameObject.tag);
	}

	void OnMouseExit()
	{
		playermovement other = (playermovement) go.GetComponent(typeof(playermovement));
		other.playerController("stop");
	}
	*/

	
	void touchProcessor()
	{

		Debug.Log (gameObject.name+" : "+nbTouches);

		if (nbTouches > 0) {
			for (int i = 0; i < nbTouches; i++) {
				Touch touch = Input.GetTouch (i);
				
				if (touch.phase == TouchPhase.Stationary) {
					Ray screenRay = Camera.main.ScreenPointToRay (touch.position);
					
					RaycastHit hit;
					if (Physics.Raycast (screenRay, out hit)) {
						print ("********* User tapped on game object " + hit.collider.gameObject.tag);

						playermovement other = (playermovement) go.GetComponent(typeof(playermovement));
						other.playerController(hit.collider.gameObject.tag);	
					}
				}

				if(touch.phase == TouchPhase.Ended){
					playermovement other = (playermovement) go.GetComponent(typeof(playermovement));

					if(gameObject.tag=="leftbt" || gameObject.tag=="rightbt" || gameObject.tag=="jumpbt")
						other.playerController("stopwalk");	

				}
			}
		}
	}
}
