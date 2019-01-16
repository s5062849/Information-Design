using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class PlayerController : MonoBehaviour {
	//list of variables
	public Camera cam;
	public NavMeshAgent agent;
	private Animator myAnim;
	float dist;
	RaycastHit hit;
	Quaternion newRotation;
	public float rotSpeed = 5.0f;
	private Quaternion savedRot;
	bool isMoving = false;


	// Use this for initialization
	void Start () {
		myAnim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		WindowRaycast ();
		DistanceCalculation ();
		RotationCalculation ();
		Sprint ();

		//stops the Navmesh moving the rotation of the player after they have moved
		if (transform.rotation != savedRot && isMoving == false) {
			transform.rotation = savedRot;
		}
	}
	//how to sprint
	void Sprint(){
		if (Input.GetKeyDown (KeyCode.LeftShift) && isMoving == true) 
		{
			agent.speed = agent.speed * 2.0f;
		}
		if (Input.GetKeyUp (KeyCode.LeftShift)) 
		{
			agent.speed = agent.speed / 2.0f;
		
		}
	}



	void WindowRaycast(){
	
		//this is how the player moves the character around the screen
		if (Input.GetMouseButtonDown (0)) {

			Ray ray = cam.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (ray, out hit)) {
				agent.SetDestination (hit.point);
				//when the player clicks a point on screen, the run annimation starts
				myAnim.SetBool ("isRunning", true);
				isMoving = true;
			}


		}
	}


	void DistanceCalculation(){
	
	//How the animation stops depengind on the distance to the destination
	dist = Vector3.Distance (hit.point, transform.position);

	if (dist < 0.7f) {

		myAnim.SetBool ("isRunning", false);
			savedRot = transform.rotation;
			isMoving = false;
				
	}

	}

	void RotationCalculation(){
		
		Vector3 relativePos = hit.point - transform.position;
		newRotation = Quaternion.LookRotation (relativePos, Vector3.up);
		newRotation.x = 0.0f;
		newRotation.z = 0.0f;

		transform.rotation = Quaternion.Slerp (transform.rotation, newRotation, rotSpeed * Time.deltaTime);




}
	}
