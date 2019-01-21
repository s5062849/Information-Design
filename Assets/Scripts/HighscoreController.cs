using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HighscoreController : MonoBehaviour {

	private PlayerData playerData;

	public Text playerHighestScore;
	public CollectiblesController cc;
	public Text playerHighestName;
	public PlayerSettings playerSettings;

	void Start()
	{
		LoadPlayerData ();
	}



	public void SubmitNewScore ()
	{
		if (cc.score > playerData.playerScore) 
		{
			Debug.Log ("Higher Than score");
			playerData.playerScore = cc.score;
			playerData.playerName = playerSettings.pd [0].playerName;
			SavePlayerData ();
		}
	}









	public void LoadPlayerData()
	{
		playerData = new PlayerData();

		if (PlayerPrefs.HasKey ("HighestScore")) 
		{
			playerData.playerScore = PlayerPrefs.GetInt ("HighestScore");
			Debug.Log (playerData.playerScore);
			Debug.Log ("Loaded player highest score");
			playerHighestScore.text = playerData.playerScore.ToString ();
		}
		if (PlayerPrefs.HasKey ("HighestScoreName")) 
		{
			playerData.playerName = PlayerPrefs.GetString ("HighestScoreName");
			playerHighestName.text = playerData.playerName;
		}

	}
	private void SavePlayerData()
	{
		PlayerPrefs.SetInt ("HighestScore", playerData.playerScore);
		PlayerPrefs.SetString ("HighestScoreName", playerData.playerName);
	}
}
