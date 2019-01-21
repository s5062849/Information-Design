using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;



public class PlayerSettings : MonoBehaviour {

	public PlayerData[] pd;

	public InputField playerInput;

	public string playerInputName;

	public CameraMovement cm;

	public Text yourName;
	//sets the player name
	public void playerEnterName()
	{
		pd[0].playerName = playerInput.text;
		yourName.text = pd [0].playerName;
	}


	void Update()
	{
		if (Input.GetKeyDown ("w")) 
		{
			Debug.Log ("Player Name :" + pd[0].playerName);
		
		}
			
	}


	public void SaveData()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream fs = File.Create (Application.persistentDataPath + "/playerData.dat");
		bf.Serialize (fs, pd);
		fs.Close ();
		Debug.Log ("Data Saved.");

	}

	public void LoadData()
	{
		if (File.Exists (Application.persistentDataPath + "/playerData.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream fs = File.Open (Application.persistentDataPath + "/playerData.dat", FileMode.Open);
			pd = (PlayerData[])bf.Deserialize (fs);
			fs.Close ();
			Debug.Log ("Data Loaded.");
		}
		//if the file doesnt exisit it will create an empty new one
		else
		{
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream fs = File.Create (Application.persistentDataPath + "/playerData.dat");
			bf.Serialize (fs, pd);
			fs.Close ();
			Debug.Log ("Data Saved.");
		}

	}


	public void CheckHighscore()
	{
		
	}


}
