using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour {

	public Camera cam;
	private RaycastHit hit;
	public GameObject playerLight;
	public GameObject mouseLight;
	public GameObject tigerLight;

	public CameraMovement cm;

	
	// Update is called once per frame
	void Update () {
		RaycastCharacter ();		
	}

	void RaycastCharacter(){

		//this is how the player moves the character around the screen
		if (Input.GetMouseButtonDown (0) && cm.setGameStarted == false) {

			Ray ray = cam.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (ray, out hit)) {
				if (hit.collider.name == "Player") {
					
					playerLight.SetActive (true);
					tigerLight.SetActive (false);
					mouseLight.SetActive (false);
					cm.player = hit.collider.gameObject;
				}
				else if (hit.collider.name == "tiger_idle") 
				{
					tigerLight.SetActive (true);
					mouseLight.SetActive (false);
					playerLight.SetActive (false);
					cm.player = hit.collider.gameObject;
				}

				else if (hit.collider.name == "MouseKnight") 
				{
					mouseLight.SetActive (true);
					tigerLight.SetActive (false);
					playerLight.SetActive (false);
					cm.player = hit.collider.gameObject;
				}

				else
				{
					Debug.Log("Did not hit player");
				}

				//agent.SetDestination (hit.point);
				//when the player clicks a point on screen, the run annimation starts
				//myAnim.SetBool ("isRunning", true);
				//isMoving = true;
			}


		}
	}




}

