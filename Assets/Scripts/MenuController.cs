using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour 
{
	public GameObject mainMenu;
	public GameObject optionsMenu;
	public GameObject titleImage;
	public GameObject contin;
	public GameObject back;
	public CameraMovement cameraMovement;

	public CharacterSelection cs;

	private void Start()
	{
		contin.SetActive (false);
		back.SetActive (false);

	}


	public void PlayGame()
	{
		mainMenu.SetActive (false);
		titleImage.SetActive (false);
		contin.SetActive (true);
		back.SetActive (true);

		cameraMovement.setGameStarted (true);
	}

	public void Confirm()
	{
		contin.SetActive (false);
		back.SetActive (false);
		cs.tigerLight.SetActive (false);
		cs.playerLight.SetActive (false);
		cs.mouseLight.SetActive (false);

	}

	public void Back()
	{
		mainMenu.SetActive (true);
		optionsMenu.SetActive (false);
		titleImage.SetActive (true);
		contin.SetActive (false);
		back.SetActive (false);

	}

	public void Options()
	{
		mainMenu.SetActive (false);
		optionsMenu.SetActive (true);
		back.SetActive (true);
	}

	public void Quit()
	{
		Debug.Log ("Quit");
		Application.Quit ();
	}


	public void FullScreen (bool isFullScreen)
	{
		Screen.fullScreen = isFullScreen;
	}


}
