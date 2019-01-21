using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Places : MonoBehaviour {

	private AudioSource source; //the players audio source
	[SerializeField] private AudioClip clip; //The audio that will play


	public Toggle orangeHut;
	public Toggle fountain;
	public Toggle greenHut;

	public CollectiblesController cC;


	void OnTriggerEnter (Collider col){

		if (col.name == "Player" || col.name == "tiger_idle" || col.name == "MouseKnight") 
		{
			if (gameObject.name == "Places (1)") 
			{
				orangeHut.isOn = true;
				cC.Score();
			}
			else if (gameObject.name == "Places") 
			{
				greenHut.isOn = true;
				cC.Score();
			}
			else if (gameObject.name == "Places (2)") 
			{
				fountain.isOn = true;
				cC.Score();
			}
		}


		Debug.Log ("You have visited: " + gameObject.name);


		source = col.GetComponent<AudioSource>();
		source.PlayOneShot (clip, 1.0f);


		Destroy (gameObject);

	}
}
