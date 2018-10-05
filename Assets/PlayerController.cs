﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class PlayerController : MonoBehaviour {

	public Camera cam;
	public NavMeshAgent agent;


	// Use this for initialization
	void Start () {
				
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(1))
		{
			
			Ray ray = cam.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;


			if (Physics.Raycast (ray, out hit)) {
				agent.SetDestination (hit.point);
			}
			else {
				Debug.Log ("Did not hit");
			}
		}



	}
}
