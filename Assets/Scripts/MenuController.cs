using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour 
{
	public GameObject play;
	public GameObject quit;
	public GameObject options;
	public GameObject titleImage;
	public GameObject contin;
	public CameraMovement cameraMovement;

	private void Start()
	{
		contin.SetActive (false);
	}


	public void PlayGame()
	{
		play.SetActive (false);
		quit.SetActive (false);
		options.SetActive (false);
		titleImage.SetActive (false);
		contin.SetActive (true);

		cameraMovement.setGameStarted (true);
	}

	public void Confirm()
	{
		contin.SetActive (false);
	}


}
