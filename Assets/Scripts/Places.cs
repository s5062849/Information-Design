using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Places : MonoBehaviour {

	private AudioSource source; //the players audio source
	[SerializeField] private AudioClip clip; //The audio that will play


	void OnTriggerEnter (Collider col){


		Debug.Log ("You have visited: " + gameObject.name);


		source = col.GetComponent<AudioSource>();
		source.PlayOneShot (clip, 1.0f);


		Destroy (gameObject);

	}
}
