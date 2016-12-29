using UnityEngine;
using System.Collections;
/*
*
* Author : PraveenMax
*/

public class playermovement : MonoBehaviour
{
	
	private Animator animator;
	private float walktriggerdpad ;
	private bool isJumping = false;
	private GameObject contraObject;
	public SpriteRenderer contraSprite;

	//controls
	private int walkDirection;

	static private KeyCode[] validKeyCodes;

	private void Init() {

	}

	// Use this for initialization
	void Start()
	{
		animator =  this.GetComponent<Animator>();
//		animator.animation= GameObject.FindGameObjectWithTag ("contra").animation;


		/*
		if(validKeyCodes!=null) return;
		validKeyCodes=(KeyCode[])System.Enum.GetValues(typeof(KeyCode));

		for (int a=0; a<validKeyCodes.Length; a++) {
			Debug.Log(validKeyCodes[a]+"\n");
		}
		*/
		animator.SetBool ("jump", true);
		contraObject = GameObject.FindGameObjectWithTag ("contra");
	}
	
	// Update is called once per frame
	void Update()
	{
		/*
		if (Input.touchCount > 0 ) {
				// Get movement of the finger since last frame
				Vector2 touchDeltaPosition = Input.GetTouch (0).deltaPosition;

			Debug.Log(touchDeltaPosition);
		}
			//playerController();

		/*
		walktriggerdpad = Input.GetAxisRaw("walktrigger");

		if(walktriggerdpad!=0f)
			animator.SetBool("walk", true);
		else
			animator.SetBool("walk", false);
		*/
		playerController ("null");
		//touchProcessor ();
	}

	void OnGUI()
	{
		GUI.TextArea(new Rect(0, 0, 250, 50), "WJ Test run by MAX .... ");
	}

	public void playerController(string tagname)
	{
		Debug.Log("Called by : "+tagname);
		//Input.GetButton ("walkright");

		/*

		if (Input.GetButton("walkright"))
		{
			animator.SetBool ("walk", true);
			if(transform.localScale.x<0f)
				transform.localScale = new Vector3(-transform.localScale.x,transform.localScale.y,transform.localScale.z);

			transform.Translate (2f* Time.deltaTime, 0, 0);
		}
		else 
		if(Input.GetButton("walkleft")) 
		{
			animator.SetBool ("walk", true);
			if(transform.localScale.x>0f)
				transform.localScale = new Vector3(-transform.localScale.x,transform.localScale.y,transform.localScale.z);

			transform.Translate(-2f* Time.deltaTime, 0, 0);
		}
		else
			animator.SetBool ("walk", false);

		if (Input.GetButton ("jump") && !isJumping) {
			animator.SetBool ("jump", true);
			isJumping = true;
			rigidbody.AddForce (Vector3.up * 0.15f * Time.deltaTime);
		} 

		*/
		if (Input.GetButton("walkright")  || tagname == "rightbt")
		{
			Debug.Log ("right bt clicked using mouse");
			animator.SetBool ("walk", true);

			if(contraObject.transform.localScale.x<0f)
				contraObject.transform.localScale = new Vector3(-contraObject.transform.localScale.x,contraSprite.transform.localScale.y,contraSprite.transform.localScale.z);

			contraObject.transform.Rotate(new Vector3(0,0,0));
			contraObject.transform.Translate (2f* Time.deltaTime, 0, 0);
		}
		else 
		if(Input.GetButton("walkleft") || tagname == "leftbt") 
		{
			animator.SetBool ("walk", true);
			//if(contraSprite.transform.localScale.x>0f)
			//	contraSprite.transform.localScale = new Vector3(-contraSprite.transform.localScale.x,contraSprite.transform.localScale.y,contraSprite.transform.localScale.z);
		//	else
			//	contraSprite.transform.localScale = new Vector3(1,1,1);
			//contraSprite.transform.Rotate(new Vector3(0,180,0));
			contraObject.transform.Translate(-2f* Time.deltaTime, 0, 0);
		}
		else
			if( tagname == "stopwalk" || tagname == "null")
				animator.SetBool ("walk", false);
		
		if ((tagname == "jumpbt" || Input.GetButton ("jump") )&& !isJumping) {
			animator.SetBool ("jump", true);
			isJumping = true;
			GetComponent<Rigidbody>().AddForce (Vector3.up * 0.15f * Time.deltaTime);
		} 
	}

	void OnCollisionEnter(Collision col)
	{
				if (col!=null  && col.rigidbody.tag=="particles") {
					Application.LoadLevel("next");
				}

				if (col!=null  &&  col.rigidbody.tag=="finalground") {
					gameObject.GetComponent<AudioSource>().Stop();
				}

		if (col != null && ( col.rigidbody.tag == "ground" || col.rigidbody.tag == "finalground")) {
						isJumping = false;
						animator.SetBool ("jump", false);
				}
	}

	/*
	void touchProcessor()
	{
				int nbTouches = Input.touchCount;
		
				if (nbTouches > 0) {
						for (int i = 0; i < nbTouches; i++) {
								Touch touch = Input.GetTouch (i);
				
								if (touch.phase == TouchPhase.Began) {
										Ray screenRay = Camera.main.ScreenPointToRay (touch.position);
					
										RaycastHit hit;
										if (Physics.Raycast (screenRay, out hit)) {
												print ("User tapped on game object " + hit.collider.gameObject.name);
												playerController (hit.collider.gameObject.tag);
										}
								}
				
						}
				}
	}
	*/
}