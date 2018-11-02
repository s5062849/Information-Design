using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ToggleScene : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {

		//changes the scene when space is pressed
		if (Input.GetKeyDown ("space")) 
		{
			if (SceneManager.GetActiveScene ().buildIndex == 0) {
				SceneManager.LoadScene (1);
			} 
			else 
			{
				SceneManager.LoadScene (0);	
			}
		}		
	}
}
