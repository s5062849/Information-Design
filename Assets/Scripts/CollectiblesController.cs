using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class CollectiblesController : MonoBehaviour {

	public CollectiblesData[] cd;


	void Awake()
	{
		//this means that data is kept between scenes
		DontDestroyOnLoad (gameObject);

		//this means that it does not creat more than one type of this object and will not create errors
		if (FindObjectsOfType (GetType ()).Length > 1) 
		{
			Destroy (gameObject);
		}


	}

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
	}


	public void Incrementcount(GameObject go)
	{
		if (go.name.Contains ("Heart")) 
		{
			cd [0].collectibleNum++;
		}
		else if (go.name.Contains ("Star")) 
		{
			cd [1].collectibleNum++;
		}
		else if (go.name.Contains ("Diamond")) 
		{
			cd [2].collectibleNum++;
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



}
