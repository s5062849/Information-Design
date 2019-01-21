using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

public class CollectiblesController : MonoBehaviour {

	public CollectiblesData[] cd;

	public PlayerController pcPlayer;
	public PlayerController pcTiger;
	public PlayerController pcMouse;

	public RandomNumber rm;

	public Text heartsText;
	public Text diamondsText;
	public Text starsText;
	public Text scoreText;
	public int score;
	public Toggle orangeHut;
	public Toggle fountain;
	public Toggle greenHut;
	public Text FinalScore;


	void Update()
	{
		if (Input.GetKeyDown ("s")) 
		{
			SaveData ();
		}
		if (Input.GetKeyDown ("l")) 
		{
			LoadData ();
		}
		Score ();
	}


	public void Incrementcount(GameObject go)
	{
		if (go.name.Contains ("Heart")) 
		{
			cd [0].collectibleNum++;
			heartsText.text = cd [0].collectibleNum.ToString ();

		}
		else if (go.name.Contains ("Star")) 
		{
			cd [1].collectibleNum++;
			starsText.text = cd [1].collectibleNum.ToString ();

		}
		else if (go.name.Contains ("Diamond")) 
		{
			cd [2].collectibleNum++;
			diamondsText.text = cd [2].collectibleNum.ToString ();
		}


		OutputCounts ();

	}


	private void OutputCounts()
	{
		Debug.Log ("Youve collected:");
		Debug.Log("Hearts: " + cd [0].collectibleNum);
		Debug.Log ("Stars: " + cd [1].collectibleNum);
		Debug.Log ("Diamonds: " + cd [2].collectibleNum);
	}


	public void SaveData()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream fs = File.Create (Application.persistentDataPath + "/gameData.dat");
		bf.Serialize (fs, cd);
		fs.Close ();
		Debug.Log ("Data Saved.");
	}


	public void LoadData()
	{
		if (File.Exists (Application.persistentDataPath + "/gameData.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream fs = File.Open (Application.persistentDataPath + "/gameData.dat", FileMode.Open);
			cd = (CollectiblesData[])bf.Deserialize (fs);
			fs.Close ();
			Debug.Log ("Data Loaded.");
		}
		else 
		{
			Debug.LogError ("The file you are trying to load does not exists");
		}
	}


	public void Score()
	{
		if (score < 0) {
			score = 0;
		}
		else 
		{
			score = (cd [0].collectibleNum + cd [1].collectibleNum + cd [2].collectibleNum) * 10 - pcPlayer.steps - pcMouse.steps - pcTiger.steps;
			if (orangeHut.isOn == true) {
				score = (score + 1) * 100;
			}
			if (fountain.isOn == true) {
				score = (score + 1) * 100;
			}
			if (greenHut.isOn == true) {
				score = (score + 1) * 100;
			}
			if (rm.points != 0) {
				score += (int)rm.points;
			}
		}
		scoreText.text = "Score: " + score.ToString ();
		FinalScore.text = scoreText.text;
	}


}
