using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour 
{
	public GameObject mainMenu;
	public GameObject optionsMenu;
	public GameObject titleImage;
	public GameObject contin;
	public GameObject back;
	public GameObject character;
	public CameraMovement cameraMovement;
	public GameObject gameMenu;
	public GameObject pickup;
	public InputField playerName;
	public GameObject des;
	public Image healthBar;
	public GameObject highScore;

	public CharacterSelection cs;

	private void Start()
	{
		contin.SetActive (false);
		back.SetActive (false);
		character.SetActive (false);
		highScore.SetActive (false);
	}


	void Update()
	{
		if (cameraMovement.gameStarted == true) {
			healthBar.fillAmount -= 0.02f * Time.deltaTime;
		} 

	}

	public void PlayGame()
	{
		character.SetActive (true);
		mainMenu.SetActive (false);
		titleImage.SetActive (false);
		contin.SetActive (true);
		back.SetActive (true);


	}

	public void Confirm()
	{
		contin.SetActive (false);
		back.SetActive (false);
		cs.tigerLight.SetActive (false);
		cs.playerLight.SetActive (false);
		cs.mouseLight.SetActive (false);
		cameraMovement.setGameStarted (true);
		character.SetActive (false);
		gameMenu.SetActive (true);


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

	public void PickUp()
	{
		pickup.SetActive (true);
	}

	public void drop()
	{
		pickup.SetActive (false);
	}


	public void examine()
	{
		des.SetActive (true);
	}

	public void HighScore()
	{
		highScore.SetActive (true);
		gameMenu.SetActive (false);
	}

	public void reload()
	{
		SceneManager.LoadScene (0);
	}
}
