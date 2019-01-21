using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;



public class PlayerSettings : MonoBehaviour {

	public PlayerData[] ps;

	public InputField playerInput;

	public string playerInputName;

	public CameraMovement cm;

	public void playerEnterName()
	{
		playerInputName = playerInput.text;

		ps [0].playerName = playerInputName;

		ps [0].playerCharacter = cm.player; 

	}


	void Update()
	{
		if (Input.GetKeyDown ("w")) 
		{
			Debug.Log ("Player Name :" + ps[0].playerName);
			Debug.Log ("Player Character :" + ps[0].playerCharacter.name);
		}
	}


	public void SaveData()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream fs = File.Create (Application.persistentDataPath + "/playerData.dat");
		bf.Serialize (fs, ps);
		fs.Close ();
		Debug.Log ("Data Saved.");

	}

	public void LoadData()
	{
		if (File.Exists (Application.persistentDataPath + "/playerData.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream fs = File.Open (Application.persistentDataPath + "/playerData.dat", FileMode.Open);
			ps = (PlayerData[])bf.Deserialize (fs);
			fs.Close ();
			Debug.Log ("Data Loaded.");
		}
		//if the file doesnt exisit it will create an empty new one
		else
		{
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream fs = File.Create (Application.persistentDataPath + "/playerData.dat");
			bf.Serialize (fs, ps);
			fs.Close ();
			Debug.Log ("Data Saved.");
		}

	}
}
