﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour {

	private AudioSource source; //the players audio source
	[SerializeField] private AudioClip clip; //The audio that will play

	CollectiblesController cc; //creates an instance of CollectiblesController

	void Start()
	{
		//gets the CollectiblesController's game object
		GameObject ccgo = GameObject.Find ("CollectiblesController");
		//makes the instance of cc equal to the script CollectiblesController
		cc = ccgo.GetComponent<CollectiblesController> ();
	}


	void OnTriggerEnter (Collider col){
		
		//outputs the game object that you have hit
		Debug.Log ("Just hit: " + gameObject.name);

		//gets the audio source
		source = col.GetComponent<AudioSource>();
		//plays the audio source
		source.PlayOneShot (clip, 1.0f);

		//destroys the game engine
		Destroy (gameObject);

		//calls the function Incrementcount and passes the game object that we collided with
		cc.Incrementcount (gameObject);


	}



}
