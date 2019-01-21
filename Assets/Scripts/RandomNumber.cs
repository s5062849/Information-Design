using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RandomNumber : MonoBehaviour {

	private float randomNum;
	public float points;
	public Text PickupText;
	bool rand;
	void Start()
	{
		rand = true;
	}


	void Update ()
	{
		if (rand == true)
		{
			pickup ();
			rand = false;
		}
	}




	public void pickup()
	{
		randomNum = Random.Range (1.0f, 10.0f);

		if (randomNum >= 5)
		{
			points = Random.Range (50.0f, 100.0f);
		}

		if (randomNum < 5) 
		{
			points = Random.Range (-50.0f, -100.0f);
		}

		points = (int)points;

		PickupText.text = "Pick Up for" + points.ToString();

	}


}
