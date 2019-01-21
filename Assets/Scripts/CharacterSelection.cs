using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour {

	public Camera cam;
	private RaycastHit hit;
	public GameObject playerLight;
	public GameObject mouseLight;
	public GameObject tigerLight;

	public GameObject mouse;
	public GameObject player;
	public GameObject tiger;

	public CameraMovement cm;

	
	// Update is called once per frame
	void Update () {
		RaycastCharacter ();		
	}

	void RaycastCharacter(){

		//this is how the player moves the character around the screen
		if (Input.GetMouseButtonDown (0) && cm.gameStarted == false) {

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

			}


		}
	}

	public void comnfirmCharacter()
	{
		if (cm.player.name == "Player") 
		{
			Destroy (mouse);
			Destroy (tiger);
		}
		else if (cm.player.name == "tiger_idle") 
		{
			Destroy (player);
			Destroy (mouse);
		}
		else if (cm.player.name == "MouseKnight") 
		{
			Destroy (player);
			Destroy (tiger);
		}
	}



}

